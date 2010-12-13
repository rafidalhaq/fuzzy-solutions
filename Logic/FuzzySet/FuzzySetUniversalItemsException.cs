using System;

namespace IGS.Fuzzy.Core
{
    public class FuzzySetUniversalItemsException : Exception
    {
        public FuzzySetUniversalItemsException(string message)
            : base(message)
        {
        }

        public FuzzySetUniversalItemsException()
        {
        }
    }
}