using System;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.Comparers
{
    public class NativeComparer<T> : IFuzzyComparer<T>
        where T : IComparable<T>
    {
        #region IFuzzyComparer<T> Members

        public FuzzyCompareGradation Compare(T first, T second)
        {
            switch (first.CompareTo(second))
            {
                case 1:
                    return FuzzyCompareGradation.Greater;
                case 0:
                    return FuzzyCompareGradation.Equal;
                default:
                    return FuzzyCompareGradation.Less;
            }
        }

        #endregion
    }
}