using ConsoleApp.Library.Infrastructure.FileProcessors;
using ConsoleApp.Library.Infrastructure.FileProcessors.Interfaces;
using ConsoleApp.Library.Services;
using ConsoleApp.Library.Services.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class DependencyInjection : NinjectModule
    {
        public override void Load()
        {
            Bind<ISourceProcessor>().To<CsvProcessor>();
            Bind<IImportedObjectService>().To<ImportedObjectService>();
        }
    }
}
