using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Writers
{
    public interface ICountWriter
    {
        void WriteCount(long count);
    }
}
