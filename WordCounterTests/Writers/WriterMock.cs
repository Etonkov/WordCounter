using WordCounter.Writers;

namespace WordCounterTests.Writers
{
    internal class WriterMock : ICountWriter
    {
        public long Count { get; private set; }

        public void WriteCount(long count)
        {
            Count = count;
        }
    }
}
