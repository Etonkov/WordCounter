using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.CharReaders
{
    public interface ICharReader: IDisposable
    {
        bool IsFinished { get; }

        char[] ReadChars();
    }
}
