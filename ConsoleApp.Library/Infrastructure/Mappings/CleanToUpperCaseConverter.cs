using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;

namespace ConsoleApp.Library.Infrastructure.Mappings
{
    public class CleanToUpperCaseConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            return text.Trim().Replace(" ", "").Replace(Environment.NewLine, "").ToUpper();
        }
    }
}