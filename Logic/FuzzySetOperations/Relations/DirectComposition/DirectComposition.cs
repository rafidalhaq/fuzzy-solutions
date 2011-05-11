using System;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Relations.DirectComposition
{
    public class DirectComposition<T> : IRelation<T, Tuple<T, T>>
    {
        public FuzzySet<Tuple<T, T>> Operate(FuzzySet<T> first, FuzzySet<T> second)
        {
            var resultSet = FuzzySet<Tuple<T, T>>.Instance();

            return null;
        }
    }
}