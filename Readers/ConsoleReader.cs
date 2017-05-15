using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter.Readers
{
    public class ConsoleReader
    {
        /// <summary>
        /// 
        /// </summary>
        private const int OuputSize = 10000;

        /// <summary>
        /// Max number of chars(bytes) that can be intered in the console.
        /// </summary>
        private const int BufferSize = 10000000;


        private char[] _allCharacters;

        public bool IsFinished { get; private set; }


        public char[] ReadChars()
        {
            Stream inputStream = Console.OpenStandardInput();
            byte[] bytes = new byte[BufferSize];
            Console.WriteLine(String.Format("Введите текст(максимум {0} символов):", BufferSize));
            int outputLength = inputStream.Read(bytes, 0, BufferSize);
            char[] chars = Encoding.UTF7.GetChars(bytes, 0, outputLength);
            Console.WriteLine(chars.Count());
            Console.ReadKey();
            return chars;
        }


        private void FirstRead()
        {

        }
    }
}
