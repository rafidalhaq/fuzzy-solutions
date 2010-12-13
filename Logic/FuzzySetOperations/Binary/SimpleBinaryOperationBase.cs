using System;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Binary
{
    public abstract class SimpleBinaryOperationBase<T> : IBinaryFuzzySetOperation<T>
    {
        protected string OperationName { private get; set; }

        #region IBinaryFuzzySetOperation<T> Members

        public FuzzySet<T> Operate(FuzzySet<T> first, FuzzySet<T> second)
        {
            if (first.ItemsEquals(second) == false)
                throw new FuzzySetUniversalItemsException(
                    string.Format("Ошибка операции \"{0}\": универсальные множества различны для нечетких множеств",
                                  OperationName));

            FuzzySet<T> resultSet = FuzzySet<T>
                .Instance()
                .Add(first);

            resultSet.SetFitnessFunction(GetFitnessFunxtion(first, second));

            return resultSet;
        }

        #endregion

        protected abstract Func<T, double> GetFitnessFunxtion(FuzzySet<T> first, FuzzySet<T> second);
    }
}