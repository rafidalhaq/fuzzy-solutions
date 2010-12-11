using System;

namespace IGS.Fuzzy.Comparers
{
    public class FuzzyComparerException : Exception
    {
        public FuzzyComparerException(string message)
            : base(message)
        {
        }
    }
}