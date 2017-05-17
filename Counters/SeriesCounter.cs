using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.CharReaders;
using WordCounter.Writers;
using WordCounter.Extentions;


namespace WordCounter.Counters
{
    public class SeriesCounter : CounterBase
    {
        public SeriesCounter(ICharReader reader, ICountWriter writer)
            : base(reader, writer)
        {
        }

        public override void Count()
        {
            long wordCount = 0;
            bool previousIsWordPart = false;

            while (Reader.IsFinished == false)
            {
                foreach (var charItem in Reader.ReadChars())
                {
                    if (charItem.IsWordPart())
                    {
                        if (previousIsWordPart == false)
                        {
                            wordCount++;
                        }

                        previousIsWordPart = true;
                    }
                    else
                    {
                        previousIsWordPart = false;
                    }
                }
            }

            Writer.WriteCount(wordCount);
        }
    }
}
