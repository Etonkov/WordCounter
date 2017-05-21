using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordCounter.CharReaders;
using WordCounter.Extentions;
using WordCounter.Writers;

namespace WordCounter.Counters
{
    public class ParallelCounter : CounterBase
    {
        private readonly object LockObj = new Object();
        private int _partNumber;

        private struct CountStorageItem
        {
            public CountStorageItem(int partNumber, int count, bool isFirstCharSeparator, bool isLastCharSeparator)
            {
                PartNumber = partNumber;
                Count = count;
                IsFirstSeparator = isFirstCharSeparator;
                IsLastSeparator = isLastCharSeparator;
            }

            public int PartNumber { get; private set; }
            public int Count { get; private set; }
            public bool IsFirstSeparator { get; private set; }
            public bool IsLastSeparator { get; private set; }

        }

        public ParallelCounter(ICharReader reader, ICountWriter writer)
            : base(reader, writer)
        {
            _partNumber = 0;
        }

        public override void Count()
        {
            var countStorage = new List<CountStorageItem>();
            var tasks = new List<Task<List<CountStorageItem>>>();

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                tasks.Add(Task.Run(() => CountTaskItem()));
            }

            foreach (var t in tasks)
            {
                t.Wait();
                countStorage.AddRange(t.Result);
            }

            Reader.Dispose();
            long wordCount = 0;
            bool isPrevSeparator = true;

            foreach (var countItem in countStorage.OrderBy(item => item.PartNumber))
            {
                wordCount += countItem.Count;

                // in case that word is cut by buffer array.
                if (!isPrevSeparator && !countItem.IsFirstSeparator)
                {
                    wordCount--;
                }

                isPrevSeparator = countItem.IsLastSeparator;
            }

            Writer.WriteCount(wordCount);
        }

        private List<CountStorageItem> CountTaskItem()
        {
            var returns = new List<CountStorageItem>();

            while (true)
            {
                char[] chars = default(char[]);
                int partNumber;

                lock (LockObj)
                {
                    if (Reader.IsFinished)
                    {
                        break;
                    }

                    partNumber = _partNumber;
                    chars = Reader.ReadChars();
                    _partNumber++;
                }

                int wordCount = 0;
                bool isPreviousSeparator = true;

                foreach (var c in chars)
                {
                    if (c.IsWordPart())
                    {
                        if (isPreviousSeparator)
                        {
                            wordCount++;
                        }

                        isPreviousSeparator = false;
                    }
                    else
                    {
                        isPreviousSeparator = true;
                    }
                }

                bool isFirstSeparator = !chars.First().IsWordPart();
                bool isLastSeparator = !chars.Last().IsWordPart();
                returns.Add(new CountStorageItem(partNumber, wordCount, isFirstSeparator, isLastSeparator));
            }

            return returns;
        }
    }
}
