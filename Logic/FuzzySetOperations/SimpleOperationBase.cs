using System;
using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations
{
    public abstract class SimpleOperationBase<T>
    {
        protected string OperationName { private get; set; }

        protected FuzzySet<T> OperateBase(IEnumerable<FuzzySet<T>> fuzzySets)
        {
            if (fuzzySets.Count() == 0)
                throw new FuzzySetOperationException(
                    string.Format("Невозможно совершить операцию \"{0}\", т.к. коллекция аргументов пуста",
                                  OperationName));

            FuzzySet<T> first = fuzzySets.First();

            if (fuzzySets.Any(x => x.ItemsEquals(first) == false))
                throw new FuzzySetOperationException(
                    string.Format("Ошибка операции \"{0}\": универсальные множества различны для нечетких множеств",
                                  OperationName));

            FuzzySet<T> resultSet = FuzzySet<T>
                .Instance()
                .Add(first);

            resultSet.SetFitnessFunction(GetFitnessFunxtion(fuzzySets));

            return resultSet;
        }

        protected abstract Func<T, double> GetFitnessFunxtion(IEnumerable<FuzzySet<T>> sets);
    }
}