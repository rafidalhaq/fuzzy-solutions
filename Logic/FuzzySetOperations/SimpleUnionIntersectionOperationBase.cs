using System;
using System.Collections.Generic;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations
{
    public abstract class SimpleUnionIntersectionOperationBase<T>
    {
        protected FuzzySet<T> SetOperation(FuzzySet<T> first, FuzzySet<T> second, string operationName, Func<double, double, double> weightSelector)
        {
            if (first.ItemsEquals(second) == false)
                throw new FuzzySetUniversalItemsException(string.Format("Ошибка операции \"{0}\": универсальные множества различны для нечетких множеств", operationName));

            var union = new FuzzySet<T>();
            var itemToWeight = new Dictionary<T, double>();
            Func<T, double> unionFitnessFunction = x => itemToWeight[x];

            union.SetFitnessFunction(unionFitnessFunction);

            foreach (var universalItem in first.UniversalItems)
            {
                union.Add(universalItem);

                itemToWeight.Add(universalItem, weightSelector(first.GetWeight(universalItem), second.GetWeight(universalItem)));
            }

            return union;
        }
    }
}