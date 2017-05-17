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
        private const int BufferSize = 100000;

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
#if DEBUG
            if (IsFinished == false)
            {
                throw new InvalidOperationException();
            }
#endif

            char[] c = default(char[]);

            if (Reader.EndOfStream == false)
            {
                c = new char[BufferSize];
                Reader.Read(c, 0, c.Length);
            }
            else
            {
                IsFinished = true;
                Reader.Close();
            }

            return c;
        }
    }
}
