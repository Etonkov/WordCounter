using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.CharReaders;
using WordCounter.Counters;
using WordCounter.Writers;

namespace WordCounter.Configurators
{
    public class KernelManager
    {
        private KernelManager() { }


        public static void ConfigureInput(IKernel kernel)
        {
            Console.WriteLine("Please select text input:");
            Console.WriteLine("1 - Console");
            Console.WriteLine("2 - File");
            Console.WriteLine("3 - DB");
            var key = Console.ReadKey(true).KeyChar;
            Console.WriteLine();

            switch (key)
            {
                case '1':
                    Console.WriteLine("Console input selected");
                    kernel.Bind<ICharReader>().To<ConsoleCharReader>();
                    break;
                case '2':
                    Console.WriteLine("File input selected");
                    kernel.Bind<ICharReader>().To<FileCharReader>();
                    break;
                case '3':
                    Console.WriteLine("DB input selected");
                    kernel.Bind<ICharReader>().To<DbCharReader>();
                    break;
                default:
                    Console.WriteLine("!!!Invalid input!!!");
                    ConfigureInput(kernel);
                    break;
            }

            Console.WriteLine();
        }

        public static void ConfigureOutput(IKernel kernel)
        {
            Console.WriteLine("Please select text output:");
            Console.WriteLine("1 - Console");
            Console.WriteLine("2 - File");
            Console.WriteLine("3 - DB");
            var key = Console.ReadKey(true).KeyChar;
            Console.WriteLine();

            switch (key)
            {
                case '1':
                    Console.WriteLine("Console output selected");
                    kernel.Bind<ICountWriter>().To<ConsoleCountWriter>();
                    break;
                case '2':
                    Console.WriteLine("File output selected");
                    kernel.Bind<ICountWriter>().To<FileCountWriter>();
                    break;
                case '3':
                    Console.WriteLine("DB output selected");
                    kernel.Bind<ICountWriter>().To<DbCountWriter>();
                    break;
                default:
                    Console.WriteLine("!!!Invalid input!!!");
                    ConfigureOutput(kernel);
                    break;
            }

            Console.WriteLine();
        }

        public static void ConfigureCounter(IKernel kernel)
        {
            Console.WriteLine("Please select counting mode:");
            Console.WriteLine("1 - Series");
            Console.WriteLine("2 - Parallel");
            Console.WriteLine("3 - Auto");
            var key = Console.ReadKey(true).KeyChar;
            Console.WriteLine();

            switch (key)
            {
                case '1':
                    Console.WriteLine("Series counting mode selected");
                    kernel.Bind<CounterBase>().To<SeriesCounter>();
                    break;
                case '2':
                    Console.WriteLine("Parallel counting mode selected");
                    kernel.Bind<CounterBase>().To<ParallelCounter>();
                    break;
                case '3':
                    {
                        Console.WriteLine("Auto counting mode selected:");
                        var inputType = kernel.Get<ICharReader>();

                        if (inputType is ConsoleCharReader)
                        {
                            Console.WriteLine("Series");
                            kernel.Bind<CounterBase>().To<SeriesCounter>();
                        }
                        else
                        {
                            Console.WriteLine("Parallel");
                            kernel.Bind<CounterBase>().To<ParallelCounter>();
                        }
                    }
                    break;
                default:
                    Console.WriteLine("!!!Invalid input!!!");
                    ConfigureCounter(kernel);
                    break;
            }

            Console.WriteLine();
        }
    }
}
