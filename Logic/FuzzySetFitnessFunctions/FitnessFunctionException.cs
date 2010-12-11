using System;

namespace IGS.Fuzzy.FitnessFunctions
{
    public class FitnessFunctionException : Exception
    {
        public FitnessFunctionException(string message) : base(message)
        {
        }
    }
}