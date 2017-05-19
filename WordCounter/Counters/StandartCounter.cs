using WordCounter.CharReaders;
using WordCounter.Extentions;
using WordCounter.Writers;


namespace WordCounter.Counters
{
    public class StandartCounter : CounterBase
    {
        public StandartCounter(ICharReader reader, ICountWriter writer)
            : base(reader, writer)
        { }

        public override void Count()
        {
            long wordCount = 0;
            bool previousIsWordPart = false;

            while (Reader.IsFinished == false)
            {
                var chars = Reader.ReadChars();

                foreach (var charItem in chars)
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
