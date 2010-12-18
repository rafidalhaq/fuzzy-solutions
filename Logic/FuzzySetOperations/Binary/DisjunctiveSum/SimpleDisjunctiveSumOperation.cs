using System;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Binary.DisjunctiveSum
{
    public class SimpleDisjunctiveSumOperation<T> : SimpleBinaryOperationBase<T>
    {
        public SimpleDisjunctiveSumOperation()
        {
            OperationName = "дизъюнктивная разность";
        }

        protected override Func<T, double> GetFitnessFunxtion(FuzzySet<T> first, FuzzySet<T> second)
        {
            IFitnessFunction<T> firstFitness = first.GetFitnessFunction();
            IFitnessFunction<T> secondFitness = second.GetFitnessFunction();

            return x =>
                       {
                           double firstWeight = firstFitness.Invoke(x);
                           double secondWeight = secondFitness.Invoke(x);

                           double firstTmpResult = firstWeight < 1 - secondWeight ? firstWeight : 1 - secondWeight;
                           double secondTmpResult = secondWeight < 1 - firstWeight ? secondWeight : 1 - firstWeight;

                           return firstTmpResult > secondTmpResult
                                      ? firstTmpResult
                                      : secondTmpResult;
                       };
        }
    }
}