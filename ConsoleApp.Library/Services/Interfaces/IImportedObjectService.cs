using ConsoleApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Services.Interfaces
{
    public interface IImportedObjectService
    {
        Dictionary<string, Dictionary<string, List<ImportedObject>>> GetSortedImportedObjects(List<ImportedObject> importeds);
    }
}
