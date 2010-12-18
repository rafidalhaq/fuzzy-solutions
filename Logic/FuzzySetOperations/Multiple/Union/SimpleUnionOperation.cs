using System;
using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Multiple.Union
{
    public class SimpleUnionOperation<T> : SimpleMultipleOperationBase<T>
    {
        public SimpleUnionOperation()
        {
            OperationName = "объединение";
        }

        protected override Func<T, double> GetFitnessFunxtion(IEnumerable<FuzzySet<T>> sets)
        {
            var fitnesses = sets.Select(x => x.GetFitnessFunction());

            return x => fitnesses.Max(y => y.Invoke(x));
        }
    }
}