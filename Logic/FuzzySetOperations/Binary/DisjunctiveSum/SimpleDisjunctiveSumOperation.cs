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
            return x =>
                       {
                           double firstFitness = first.GetFitnessFunction().Invoke(x);
                           double secondFitness = second.GetFitnessFunction().Invoke(x);

                           double firstTmpResult = firstFitness < 1 - secondFitness ? firstFitness : 1 - secondFitness;
                           double secondTmpResult = secondFitness < 1 - firstFitness ? secondFitness : 1 - firstFitness;

                           return firstTmpResult > secondTmpResult
                                      ? firstTmpResult
                                      : secondTmpResult;
                       };
        }
    }
}