using System;
using System.Collections.Generic;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.Comparers
{
    public class ExpertListBasedComparer<T> : IFuzzyComparer<T>
    {
        private readonly IDictionary<Tuple<T, T>, FuzzyCompareGradation> pairToValue = new Dictionary<Tuple<T, T>, FuzzyCompareGradation>();

        public FuzzyCompareGradation Compare(T first, T second)
        {
            FuzzyCompareGradation value;

            if(pairToValue.TryGetValue(new Tuple<T, T>(first, second), out value))
                return value;

            throw new FuzzyComparerException("Невозможно сравнить элементы на основании оценок эксперта, т.к. соответствие не было задано");
        }

        public void AddPair(T first, T second, FuzzyCompareGradation fuzzyCompareGradation)
        {
            pairToValue.Add(new Tuple<T, T>(first, second), fuzzyCompareGradation);
        }
    }
}