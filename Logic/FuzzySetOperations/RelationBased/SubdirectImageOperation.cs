using System;
using System.Linq;
using IGS.Fuzzy.Core;
using IGS.MathExtensions.Binary;

namespace IGS.Fuzzy.FuzzySetOperations.RelationBased
{
    public class SubdirectImageOperation<T> : ImageOperationBase<T>
    {
        protected override Func<FuzzySet<T>, double> GetFitnessFunction(FuzzySet<T> fuzzySet)
        {
            return set => fuzzySet.UniversalItems.Min(x => BinaryExtensions.Truncation(fuzzySet.GetWeight(x), set.GetWeight(x)));
        }
    }
}