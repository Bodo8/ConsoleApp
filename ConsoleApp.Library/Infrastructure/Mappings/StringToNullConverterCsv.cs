using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Infrastructure.Mappings
{
    public class StringToNullConverterCsv : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if ( text == "NULL" || text == "null")
                return null;

            if (string.IsNullOrWhiteSpace(text))
                return "";

            if (text.Contains(":"))
            {
                text = text.Substring(text.IndexOf(":") + 1);
                return text.Trim().Replace(" ", "").Replace(Environment.NewLine, "").ToLower();
            }

            return text.Trim().Replace(" ", "").Replace(Environment.NewLine, "").ToLower();
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (((string)value) == null)
                return "NULL";

            return value.ToString();
        }
    }
}
