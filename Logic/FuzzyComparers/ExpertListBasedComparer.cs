using System;
using System.Collections.Generic;
using IGS.Fuzzy.Core.FuzzyGradation;

namespace IGS.Fuzzy.Comparers
{
    public class ExpertListBasedComparer<T> : IFuzzyComparer<T>
    {
        private readonly IDictionary<Tuple<T, T>, FuzzyCompareGradation> pairToValue =
            new Dictionary<Tuple<T, T>, FuzzyCompareGradation>();

        #region IFuzzyComparer<T> Members

        public FuzzyCompareGradation Compare(T first, T second)
        {
            FuzzyCompareGradation value;

            if (pairToValue.TryGetValue(new Tuple<T, T>(first, second), out value))
                return value;

            throw new FuzzyComparerException(
                "���������� �������� �������� �� ��������� ������ ��������, �.�. ������������ �� ���� ������");
        }

        #endregion

        public void AddPair(T first, T second, FuzzyCompareGradation fuzzyCompareGradation)
        {
            pairToValue.Add(new Tuple<T, T>(first, second), fuzzyCompareGradation);
        }
    }
}