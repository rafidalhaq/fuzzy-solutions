using System;
using System.Linq;
using IGS.Fuzzy.Core;
using IGS.MathExtensions.Binary;

namespace IGS.Fuzzy.FuzzySetOperations.RelationBased
{
    public class SuperdirectImageOperation<T> : ImageOperationBase<T>
    {
        protected override Func<FuzzySet<T>, double> GetFitnessFunction(FuzzySet<T> fuzzySet)
        {
            return set => fuzzySet.UniversalItems.Min(x => BinaryExtensions.Truncation(set.GetWeight(x), fuzzySet.GetWeight(x)));
        }
    }
}