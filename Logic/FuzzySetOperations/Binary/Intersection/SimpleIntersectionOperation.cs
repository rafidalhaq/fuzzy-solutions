using System;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Binary.Intersection
{
    public class SimpleIntersectionOperation<T> : SimpleBinaryOperationBase<T>
    {
        public SimpleIntersectionOperation()
        {
            OperationName = "пересечение";
        }

        protected override Func<T, double> GetFitnessFunxtion(FuzzySet<T> first, FuzzySet<T> second)
        {
            return x =>
                       {
                           double firstFitness = first.GetFitnessFunction().Invoke(x);
                           double secondFitness = second.GetFitnessFunction().Invoke(x);

                           return firstFitness < secondFitness
                                      ? firstFitness
                                      : secondFitness;
                       };
        }
    }
}