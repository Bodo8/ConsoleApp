using ConsoleApp.Library.Infrastructure.FileProcessors.Interfaces;
using ConsoleApp.Library.Models;
using ConsoleApp.Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library
{
    public class MainClass
    {
        private readonly IImportedObjectService _importedObjectService;
        private readonly ISourceProcessor _sourceProcessor;

        public MainClass(IImportedObjectService importedObjectService, ISourceProcessor sourceProcessor)
        {
            _importedObjectService = importedObjectService;
            _sourceProcessor = sourceProcessor;
        }

        public void RunApp()
        {
            List<ImportedObject> importeds = _sourceProcessor.GetItems("assets\\data.csv");
            List<ImportedObject> cleanRows = importeds.Where(x => x.ParentName.Length > 0).ToList();
            Dictionary<string, Dictionary<string, List<ImportedObject>>> sortedObjects = _importedObjectService.GetSortedImportedObjects(cleanRows);

            ShowResult(sortedObjects);
        }

        private void ShowResult(Dictionary<string, Dictionary<string, List<ImportedObject>>> sortedObjects)
        {
            foreach (var importedObject in sortedObjects)
            {
                Console.WriteLine($"Database '{importedObject.Key}' ({importedObject.Value.Count} tables)");

                foreach (var item in importedObject.Value)
                {
                    Console.WriteLine($"\tTable '{item.Key}' ({item.Value.Count} columns)");

                    foreach (var table in item.Value)
                    {
                        Console.WriteLine($"\t\tColumn '{table.Name}' with {table.DataType} data type" +
                            $" {(table.IsNullable == true ? "accepts nulls" : "with no nulls")}");
                    }

                }
            }
            Console.ReadLine();
        }
    }
}
