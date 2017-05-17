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
        /// <summary>
        /// Max number of chars(bytes) that can be intered in the console.
        /// </summary>
        private const int BufferSize = 10000000;


        public ConsoleCharReader()
        {
            IsFinished = false;
        }


        public bool IsFinished { get; private set; }

        public void Dispose() { }

        public char[] ReadChars()
        {
#if DEBUG
            if (IsFinished)
            {
                throw new InvalidOperationException();
            }
#endif

            char[] chars = default(char[]);
            Stream inputStream = Console.OpenStandardInput();
            byte[] bytes = new byte[BufferSize];
            Console.WriteLine(String.Format("Enter the text(max {0} characters):", BufferSize));
            int outputLength = inputStream.Read(bytes, 0, BufferSize);
            chars = Console.InputEncoding.GetChars(bytes, 0, outputLength);
            IsFinished = true;
            return chars;
        }
    }
}
