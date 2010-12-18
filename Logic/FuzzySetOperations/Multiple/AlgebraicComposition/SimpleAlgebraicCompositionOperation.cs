using System;
using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Multiple.AlgebraicComposition
{
    public class SimpleAlgebraicCompositionOperation<T> : SimpleMultipleOperationBase<T>
    {
        public SimpleAlgebraicCompositionOperation()
        {
            OperationName = "алгебраическое произведение";
        }

        protected override Func<T, double> GetFitnessFunxtion(IEnumerable<FuzzySet<T>> sets)
        {
            IEnumerable<IFitnessFunction<T>> fitnesses = sets.Select(x => x.GetFitnessFunction());

            return
                x =>
                fitnesses.Aggregate<IFitnessFunction<T>, double>(1,
                                                                 (current, fitnessFunction) =>
                                                                 current*fitnessFunction.Invoke(x));
        }
    }
}