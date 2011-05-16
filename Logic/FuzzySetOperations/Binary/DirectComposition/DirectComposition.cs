using System;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Binary.DirectComposition
{
    public class DirectComposition<T> : IBinaryFuzzySetOperation<T, Tuple<T, T>>
    {
        public FuzzySet<Tuple<T, T>> Operate(FuzzySet<T> first, FuzzySet<T> second)
        {
            var resultSet = FuzzySet<T>.InstanceRelation(first, second);

            resultSet.SetFitnessFunction(x => Math.Min(first.GetWeight(x.Item1), second.GetWeight(x.Item2)));

            return resultSet;
        }
    }
}