using System;
using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FitnessFunctions
{
    public class SwitchFitnessFunction<T> : IFitnessFunction<T>
    {
        private readonly IDictionary<T, double> itemsWeights;

        public SwitchFitnessFunction(IDictionary<T, double> itemsWeights)
        {
            this.itemsWeights = itemsWeights;
        }

        #region IFitnessFunction<T> Members

        public double Invoke(T item)
        {
            double value;

            if (itemsWeights.TryGetValue(item, out value))
                return value;

            throw new FuzzySetUniversalItemsException(
                "Функция соответствия не определена для элемента нечёткого множества, который был передан в качестве аргумента.");
        }

        public double GetMax()
        {
            return itemsWeights.Values.Max();
        }

        public FuzzySet<T> ParentSet
        {
            set { }
        }

        #endregion
    }
}