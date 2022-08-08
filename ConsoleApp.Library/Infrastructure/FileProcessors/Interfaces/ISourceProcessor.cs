
using ConsoleApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Library.Infrastructure.FileProcessors.Interfaces
{
    public interface ISourceProcessor
    {
        List<ImportedObject> GetItems(string fileName);
        void SaveItems(List<ImportedObject> items, string fileName);
    }
}
