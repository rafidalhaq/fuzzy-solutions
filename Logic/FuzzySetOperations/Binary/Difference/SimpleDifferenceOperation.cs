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
            return x =>
                       {
                           double firstFitness = first.GetFitnessFunction().Invoke(x);
                           double secondFitness = 1 - second.GetFitnessFunction().Invoke(x);

                           return firstFitness < secondFitness
                                      ? firstFitness
                                      : secondFitness;
                       };
        }
    }
}