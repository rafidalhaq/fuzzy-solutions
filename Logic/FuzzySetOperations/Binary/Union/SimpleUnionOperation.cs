using System;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Binary.Union
{
    public class SimpleUnionOperation<T> : SimpleBinaryOperationBase<T>
    {
        public SimpleUnionOperation()
        {
            OperationName = "объединение";
        }

        protected override Func<T, double> GetFitnessFunxtion(FuzzySet<T> first, FuzzySet<T> second)
        {
            return x =>
                       {
                           double firstWeight = first.GetFitnessFunction().Invoke(x);
                           double secondWeight = second.GetFitnessFunction().Invoke(x);

                           return firstWeight > secondWeight
                                      ? firstWeight
                                      : secondWeight;
                       };
        }
    }
}