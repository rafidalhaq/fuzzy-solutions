using System;

namespace IGS.Fuzzy.FuzzySetOperations
{
    public class FuzzySetOperationException : Exception
    {
        public FuzzySetOperationException(string message)
            : base(message)
        {
        }
    }
}