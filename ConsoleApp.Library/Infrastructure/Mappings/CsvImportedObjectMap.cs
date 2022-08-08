using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ConsoleApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Infrastructure.Mappings
{
    public class CsvImportedObjectMap : ClassMap<ImportedObject>
    {
        public CsvImportedObjectMap()
        {
            Map(m => m.Name).Name("Name").TypeConverter<CleanStringConverter>();
            Map(m => m.Type).Name("Type").TypeConverter<CleanToUpperCaseConverter>();
            Map(m => m.Schema).Name("Schema").TypeConverter<CleanStringConverter>();
            Map(m => m.ParentName).Name("ParentName").TypeConverter<CleanStringConverter>();
            Map(m => m.ParentType).Name("ParentType").TypeConverter<CleanToUpperCaseConverter>();
            Map(m => m.DataType).Name("DataType").TypeConverter<StringToNullConverterCsv>();
            Map(m => m.IsNullable).Name("IsNullable").TypeConverter<BooleanConverterCsv>();
        }
    }
}
