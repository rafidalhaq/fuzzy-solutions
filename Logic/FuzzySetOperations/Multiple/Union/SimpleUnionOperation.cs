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
            IEnumerable<IFitnessFunction<T>> fitnesses = sets.Select(x => x.FitnessFunction);

            return x => fitnesses.Max(y => y.Invoke(x));
        }
    }
}