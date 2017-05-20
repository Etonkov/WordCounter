using System;

namespace WordCounter.CharReaders
{
    public interface ICharReader: IDisposable
    {
        bool IsFinished { get; }

        char[] ReadChars();
    }
}
