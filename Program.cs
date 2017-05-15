using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Readers;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleReader consoleReader = new ConsoleReader();
            consoleReader.ReadChars();
            var s1 = Console.ReadLine();
            var s2 = Console.ReadLine();
            var s3 = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.ReadKey();
        }
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind<IMessageService>().To<MessageService>();
        }
    }
}
