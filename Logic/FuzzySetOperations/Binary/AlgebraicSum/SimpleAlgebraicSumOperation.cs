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
            var firstFitness = first.GetFitnessFunction();
            var secondFitness = second.GetFitnessFunction();

            return x =>
                       {
                           double firstWeight = firstFitness.Invoke(x);
                           double secondWeight = secondFitness.Invoke(x);

                           return firstWeight + secondWeight - firstWeight*secondWeight;
                       };
        }
    }
}