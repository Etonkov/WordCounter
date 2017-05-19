using System;
using System.Linq;

namespace WordCounter.Extentions
{
    public static class CharExtentions
    {
        private static readonly char[] SpecialWordChars = { '-', '_' };

        public static bool IsWordPart(this char c)
        {
            return Char.IsLetterOrDigit(c) || SpecialWordChars.Contains(c);
        }
    }
}
