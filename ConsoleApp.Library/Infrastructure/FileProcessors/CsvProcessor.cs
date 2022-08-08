using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using CsvHelper;
using System.Globalization;
using ConsoleApp.Library.Infrastructure.FileProcessors.Interfaces;
using ConsoleApp.Library.Models;
using ConsoleApp.Library.Infrastructure.Mappings;
using CsvHelper.Configuration;

namespace ConsoleApp.Library.Infrastructure.FileProcessors
{
    public class CsvProcessor : ISourceProcessor
    {
        public List<ImportedObject> GetItems(string fileName)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                DetectDelimiter = true,
                HeaderValidated = null,
                MissingFieldFound = null
            };

            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<CsvImportedObjectMap>();

                return csv.GetRecords<ImportedObject>().ToList();
            }
        }

        public void SaveItems(List<ImportedObject> products, string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            using (var csv = new CsvWriter(writer, new CultureInfo("pl-PL")))
            {
                csv.Context.RegisterClassMap<CsvImportedObjectMap>();

                csv.WriteRecords(products);
            }
        }
    }
}
