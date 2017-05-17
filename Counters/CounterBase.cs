using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.CharReaders;
using WordCounter.Writers;

namespace WordCounter.Counters
{
    public abstract class CounterBase : ICounter
    {
        protected readonly ICharReader Reader;
        protected readonly ICountWriter Writer;

        protected CounterBase(ICharReader reader, ICountWriter writer)
        {
            Reader = reader;
            Writer = writer;
        }

        public abstract void Count();
    }
}
