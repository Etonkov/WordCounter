using Ninject;
using System;
using WordCounter.Configurators;
using WordCounter.Counters;

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
                Console.WriteLine();
                KernelManager.ConfigureOutput(ninjectKernel);
                Console.WriteLine();
                KernelManager.ConfigureCounter(ninjectKernel);
                Console.WriteLine();

                try
                {
                    var counter = ninjectKernel.Get<CounterBase>();
                    counter.Count();
                }
                catch (Exception e)
                {
                    Console.WriteLine("***!!!ERROR!!!***");
                    Console.WriteLine("Message: " + e.Message);
                }

                Console.WriteLine();
                Console.WriteLine("Press 'ESC' to exit or any key to continue...");

                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.WriteLine();
            }
        }
    }
}
