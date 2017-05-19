using System;
using System.IO;

namespace WordCounter.Writers
{
    public class FileCountWriter : ICountWriter
    {
        private readonly string FilePath;

        public FileCountWriter(string filePath)
        {
            FilePath = filePath;
        }

        public void WriteCount(long count)
        {
            using (var file = new StreamWriter(FilePath, true))
            {
                file.WriteLine("[{0}] count: {1}", DateTime.Now, count);
            }

            Console.WriteLine(String.Format("Result was saved in {0}", FilePath));
        }
    }
}
