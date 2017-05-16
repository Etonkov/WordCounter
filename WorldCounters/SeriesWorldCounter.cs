using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.CharReaders;
using WordCounter.Writers;

namespace WordCounter.WorldCounters
{
    public class SeriesWorldCounter : WorldCounterBase
    {
        public SeriesWorldCounter(ICharReader reader, ICountWriter writer)
            : base(reader, writer)
        {
        }

        public override void CountWorlds()
        {
            long worldCount = 0;


            while (Reader.IsFinished)
            {
                char[] c = Reader.ReadChars();



                c.Count();
            }
    }
}
