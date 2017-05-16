using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Writers
{
    public class ConsoleCountWriter : ICountWriter
    {
        public void WriteCount(long count)
        {
            Console.WriteLine(String.Format("Количество слов в тексте: {0}", count));
        }
    }
}
