using System;

namespace WordCounter.Writers
{
    public class ConsoleCountWriter : ICountWriter
    {
        public void WriteCount(long count)
        {
            Console.WriteLine(String.Format("Word count: {0}", count));
        }
    }
}
