using System;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Binary.Difference
{
    public class SimpleDifferenceOperation<T> : SimpleBinaryOperationBase<T>
    {
        public SimpleDifferenceOperation()
        {
            OperationName = "разность";
        }

        protected override Func<T, double> GetFitnessFunxtion(FuzzySet<T> first, FuzzySet<T> second)
        {
            IFitnessFunction<T> firstFitness = first.FitnessFunction;
            IFitnessFunction<T> secondFitness = second.FitnessFunction;

            return x =>
                       {
                           double firstWeight = firstFitness.Invoke(x);
                           double secondWeight = 1 - secondFitness.Invoke(x);

                           return firstWeight < secondWeight
                                      ? firstWeight
                                      : secondWeight;
                       };
        }
    }
}