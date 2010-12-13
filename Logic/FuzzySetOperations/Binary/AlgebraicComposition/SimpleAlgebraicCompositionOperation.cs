using System;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Binary.AlgebraicComposition
{
    public class SimpleAlgebraicCompositionOperation<T> : SimpleBinaryOperationBase<T>
    {
        public SimpleAlgebraicCompositionOperation()
        {
            OperationName = "алгебраическое произведение";
        }

        protected override Func<T, double> GetFitnessFunxtion(FuzzySet<T> first, FuzzySet<T> second)
        {
            return x =>
                       {
                           double firstWeight = first.GetFitnessFunction().Invoke(x);
                           double secondWeight = second.GetFitnessFunction().Invoke(x);

                           return firstWeight*secondWeight;
                       };
        }
    }
}