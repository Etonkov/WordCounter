using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.CharReaders;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            ICharReader reader = new ConsoleCharReader();

            while (true)
            {
                char[] c;
                bool isFinished;

                lock ("lock")
                {
                    isFinished = reader.IsFinished;

                    if (isFinished == false)
                    {
                        c = reader.ReadChars();
                    }
                    else
                    {
                        break;
                    }
                }


                c.Count();
            }
        }
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind<IMessageService>().To<MessageService>();
        }
    }
}
