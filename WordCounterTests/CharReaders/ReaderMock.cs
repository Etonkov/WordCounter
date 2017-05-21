using System;
using System.Linq;
using WordCounter.CharReaders;

namespace WordCounterTests.CharReaders
{
    internal class ReaderMock : ICharReader
    {
        private readonly char[] Text;
        private readonly int BufferSize;
        private int _position;
        private readonly int TotalSize;

        public ReaderMock(string text, int bufferSize)
        {
            Text = text.ToCharArray();
            TotalSize = Text.Count();
            BufferSize = bufferSize;
            _position = 0;
            IsFinished = false;
        }

        public bool IsFinished { get; private set; }

        public char[] ReadChars()
        {
            char[] c = new char[BufferSize];

            if (!IsFinished)
            {
                Array.Copy(Text, _position, c, 0, Math.Min(TotalSize - _position, BufferSize));
                _position += BufferSize;
                IsFinished = _position > TotalSize;
            }
            else
            {
                throw new InvalidOperationException();
            }

            return c;
        }

        public void Dispose()
        {
        }
    }
}
