using Ninject;
using System;
using System.Configuration;
using WordCounter.CharReaders;
using WordCounter.Counters;
using WordCounter.Writers;

namespace WordCounter.Configurators
{
    public class KernelManager
    {
        private const string InputFilePath = "textfile.txt";
        private const string OutputFilePath = "result.txt";
        private const string DbConnectionStringName = "TestConnectionString";

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
                    Console.WriteLine(String.Format("Default input file path is {0}", InputFilePath));
                    kernel.Bind<ICharReader>().To<FileCharReader>().WithConstructorArgument(InputFilePath);
                    break;
                case '3':
                    Console.WriteLine("DB input selected");
                    var connectionSettings = ConfigurationManager.ConnectionStrings[DbConnectionStringName];
                    var connectionString = connectionSettings.ConnectionString;
                    Console.WriteLine(String.Format("Default connection string is {0}", DbConnectionStringName));
                    kernel.Bind<ICharReader>().To<DbCharReader>().WithConstructorArgument(connectionString);
                    break;
                default:
                    Console.WriteLine("!!!Invalid input!!!");
                    ConfigureInput(kernel);
                    break;
            }
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
                    Console.WriteLine(String.Format("Default output file path is {0}", OutputFilePath));
                    kernel.Bind<ICountWriter>().To<FileCountWriter>().WithConstructorArgument(OutputFilePath);
                    break;
                case '3':
                    Console.WriteLine("DB output selected");
                    var connectionSettings = ConfigurationManager.ConnectionStrings[DbConnectionStringName];
                    var connectionString = connectionSettings.ConnectionString;
                    Console.WriteLine(String.Format("Default connection string is {0}", DbConnectionStringName));
                    kernel.Bind<ICountWriter>().To<DbCountWriter>().WithConstructorArgument(connectionString);
                    break;
                default:
                    Console.WriteLine("!!!Invalid input!!!");
                    ConfigureOutput(kernel);
                    break;
            }
        }

        public static void ConfigureCounter(IKernel kernel)
        {
            Console.WriteLine("Please select counting mode:");
            Console.WriteLine("1 - Standart");
            Console.WriteLine("2 - Ignore digits");
            Console.WriteLine("3 - Parallel");
            var key = Console.ReadKey(true).KeyChar;
            Console.WriteLine();

            switch (key)
            {
                case '1':
                    Console.WriteLine("Standart counting mode selected");
                    kernel.Bind<CounterBase>().To<StandartCounter>();
                    break;
                case '2':
                    Console.WriteLine("Ignore digits counting mode selected");
                    kernel.Bind<CounterBase>().To<IgnoreDigitCounter>();
                    break;
                case '3':
                    Console.WriteLine("Parallel counting mode selected");
                    kernel.Bind<CounterBase>().To<ParallelCounter>();
                    break;
                default:
                    Console.WriteLine("!!!Invalid input!!!");
                    ConfigureCounter(kernel);
                    break;
            }
        }
    }
}
