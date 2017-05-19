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
                KernelManager.ConfigureOutput(ninjectKernel);
                KernelManager.ConfigureCounter(ninjectKernel);

                var counter = ninjectKernel.Get<CounterBase>();
                counter.Count();

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
