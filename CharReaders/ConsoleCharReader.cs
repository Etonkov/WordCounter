using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter.CharReaders
{
    public class ConsoleCharReader: ICharReader
    {
        ///// <summary>
        ///// Max array size of the ReadChars() method result.
        ///// </summary>
        //private const int OuputSize = 10000;

        /// <summary>
        /// Max number of chars(bytes) that can be intered in the console.
        /// </summary>
        private const int BufferSize = 10000000;

        //private bool _isFinished;


        public ConsoleCharReader()
        {
            IsFinished = false;
        }


        public bool IsFinished { get; private set; }

        public void Dispose() { }

        public char[] ReadChars()
        {
#if DEBUG
            if (IsFinished == false)
            {
                throw new InvalidOperationException();
            }
#endif

            char[] chars = default(char[]);
            Stream inputStream = Console.OpenStandardInput();
            byte[] bytes = new byte[BufferSize];
            Console.WriteLine(String.Format("Введите текст(максимум {0} символов):", BufferSize));
            int outputLength = inputStream.Read(bytes, 0, BufferSize);
            chars = Encoding.UTF7.GetChars(bytes, 0, outputLength);
            //Console.WriteLine(result.Count());
            //Console.ReadKey();
            IsFinished = true;
            return chars;
        }
    }
}
