using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.CharReaders;
using WordCounter.Writers;

namespace WordCounter.Counters
{
    public class ParallelCounter : CounterBase
    {
        public ParallelCounter(ICharReader reader, ICountWriter writer) : base(reader, writer)
        {
        }

        public override void Count()
        {
            throw new NotImplementedException();
        }
    }
}
