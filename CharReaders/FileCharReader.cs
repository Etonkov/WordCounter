using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.CharReaders
{
    public class FileCharReader: ICharReader
    {
        /// <summary>
        /// Max number of chars that can be returned in the ReadChars() method.
        /// </summary>
        private const int BufferSize = 1000000;

        private const string FilePath = "textfile.txt";

        private readonly StreamReader Reader;

        public bool IsFinished { get; private set; }


        public FileCharReader()
        {
            IsFinished = false;
            Reader = new StreamReader(FilePath);
        }


        public char[] ReadChars()
        {
            char[] c = default(char[]);

            if (Reader.Peek() >= 0)
            {
                c = new char[BufferSize];
                Reader.Read(c, 0, c.Length);
            }
            else
            {
                IsFinished = true;
            }

            return c;
        }

        public void Dispose()
        {
            Reader.Dispose();
        }
    }
}
