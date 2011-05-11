using System;
using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Multiple.Intersection
{
    public class SimpleIntersectionOperation<T> : SimpleMultipleOperationBase<T>
    {
        public SimpleIntersectionOperation()
        {
            OperationName = "пересечение";
        }

        protected override Func<T, double> GetFitnessFunxtion(IEnumerable<FuzzySet<T>> sets)
        {
            IEnumerable<IFitnessFunction<T>> fitnesses = sets.Select(x => x.GetFitnessFunction());

            return x => fitnesses.Min(y => y.Invoke(x));
        }
    }
}