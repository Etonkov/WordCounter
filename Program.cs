using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.CharReaders;
using WordCounter.Counters;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel();
            //ninjectKernel.Load();
            Console.ReadKey();
        }
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind<CounterBase>().To<MessageService>();
        }
    }

    public class EmployeeExportModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<CounterBase>().To<SeriesCounter>().
        }
    }
}
