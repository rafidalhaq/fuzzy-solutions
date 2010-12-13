using System;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Binary.AlgebraicSum
{
    public class SimpleAlgebraicSumOperation<T> : SimpleBinaryOperationBase<T>
    {
        public SimpleAlgebraicSumOperation()
        {
            OperationName = "алгебраическая сумма";
        }

        protected override Func<T, double> GetFitnessFunxtion(FuzzySet<T> first, FuzzySet<T> second)
        {
            return x =>
                       {
                           double firstWeight = first.GetFitnessFunction().Invoke(x);
                           double secondWeight = second.GetFitnessFunction().Invoke(x);

                           return firstWeight + secondWeight - firstWeight*secondWeight;
                       };
        }
    }
}