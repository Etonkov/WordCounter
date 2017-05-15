using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Readers
{
    public class FileReader
    {
        public void Read()
        {
            StreamReader sr = new StreamReader("E:\\textfile.txt");
            string s;

            while (sr.EndOfStream != true)
            {
                s = sr.ReadLine();
            }
        }
    }
}
