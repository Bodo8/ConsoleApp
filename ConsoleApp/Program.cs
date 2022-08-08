namespace ConsoleApp
{
    using ConsoleApp.Library;
    using ConsoleApp.Library.Infrastructure.FileProcessors;
    using ConsoleApp.Library.Infrastructure.FileProcessors.Interfaces;
    using ConsoleApp.Library.Services;
    using ConsoleApp.Library.Services.Interfaces;
    using Ninject;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        static void Main(string[] args)
        {
            StandardKernel _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
            ISourceProcessor _iCsvProcessor = _kernel.Get<ISourceProcessor>();
            IImportedObjectService _iCsvReadService = _kernel.Get<IImportedObjectService>();
            MainClass mainClass = new MainClass(_iCsvReadService, _iCsvProcessor);
            
            mainClass.RunApp();

        }
    }
}
