using System;
using System.IO;
using System.Text;

namespace WordCounter.CharReaders
{
    public class FileCharReader: ICharReader
    {
        /// <summary>
        /// Max number of chars that can be returned in the ReadChars() method.
        /// </summary>
        private const int BufferSize = 100000;
        private readonly StreamReader Reader;

        public FileCharReader(string filePath)
        {
            Console.WriteLine("File reading is initialized...");
            Reader = new StreamReader(filePath, Encoding.Default);
            IsFinished = Reader.EndOfStream;
        }

        public bool IsFinished { get; private set; }

        public char[] ReadChars()
        {
#if DEBUG
            if (IsFinished)
            {
                throw new InvalidOperationException();
            }
#endif
            var c = new char[BufferSize];
            Reader.Read(c, 0, BufferSize);

            if (Reader.EndOfStream)
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
