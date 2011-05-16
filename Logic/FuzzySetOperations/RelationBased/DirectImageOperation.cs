using System;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Multiple;

namespace IGS.Fuzzy.FuzzySetOperations.RelationBased
{
    public class DirectImageOperation<T> : ImageOperationBase<T>
    {
        private readonly IMultipleFuzzySetOperation<T> intersection;

        public DirectImageOperation(IMultipleFuzzySetOperation<T> intersection)
        {
            this.intersection = intersection;
        }

        protected override Func<FuzzySet<T>, double> GetFitnessFunction(FuzzySet<T> fuzzySet)
        {
            return x => intersection.Operate(x, fuzzySet).FitnessFunction.GetMax();
        }
    }
}