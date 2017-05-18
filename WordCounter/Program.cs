using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.CharReaders;
using WordCounter.Configurators;
using WordCounter.Counters;
using WordCounter.Writers;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Welcome to World Counter!***");
            Console.WriteLine();
            Console.WriteLine("*This program counts the number of words in the text.*");
            Console.WriteLine();

            while (true)
            {
                IKernel ninjectKernel = new StandardKernel();
                KernelManager.ConfigureInput(ninjectKernel);
                KernelManager.ConfigureOutput(ninjectKernel);
                KernelManager.ConfigureCounter(ninjectKernel);

                var counter = ninjectKernel.Get<CounterBase>();
                counter.Count();

                Console.WriteLine();
                Console.WriteLine("Press 'ESC' to exit or any key to continue...");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.WriteLine();
            }
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
