using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.CharReaders;
using WordCounter.Writers;

namespace WordCounter.WorldCounters
{
    public abstract class WorldCounterBase : IWorldCounter
    {
        protected readonly ICharReader Reader;
        protected readonly ICountWriter Writer;

        protected WorldCounterBase(ICharReader reader, ICountWriter writer)
        {
            Reader = reader;
            Writer = writer;
        }

        public abstract void CountWorlds();
    }
}
