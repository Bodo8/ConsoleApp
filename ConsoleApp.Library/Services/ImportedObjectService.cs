using ConsoleApp.Library.Infrastructure.FileProcessors.Interfaces;
using ConsoleApp.Library.Models;
using ConsoleApp.Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Services
{
    public class ImportedObjectService : IImportedObjectService
    {
        public Dictionary<string, Dictionary<string, List<ImportedObject>>> GetSortedImportedObjects(List<ImportedObject> importeds)
        {
            var databases = importeds
                .Where(x => x.ParentType == "DATABASE")
                .GroupBy(x => x.ParentName).ToDictionary(
                x => x.Key, x => x.ToList());

            var tabsAll = importeds
                .Where(x => x.ParentType == "TABLE")
                .GroupBy(x => x.ParentName).ToDictionary(
                x => x.Key, x => x.ToList());

            Dictionary<string, Dictionary<string, List<ImportedObject>>> result = new Dictionary<string, Dictionary<string, List<ImportedObject>>>();

            foreach (var db in databases)
            {
                Dictionary<string, List<ImportedObject>> tabs = new Dictionary<string, List<ImportedObject>>();

                foreach (var item in db.Value)
                { 
                    foreach (var tab in tabsAll)
                    {
                        if (tab.Key == item.Name)
                            tabs.Add(tab.Key, tab.Value);
                    }
                }
                result.Add(db.Key, tabs);
            }

            return result;
        }
    }
}
