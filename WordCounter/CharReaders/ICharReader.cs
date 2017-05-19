namespace WordCounter.CharReaders
{
    public interface ICharReader
    {
        bool IsFinished { get; }

        char[] ReadChars();
    }
}
