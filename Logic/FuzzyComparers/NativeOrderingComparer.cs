using System;
using IGS.Fuzzy.Core.FuzzyGradation;

namespace IGS.Fuzzy.Comparers
{
    public class NativeOrderingComparer<TUniversalItem> : IFuzzyComparer<TUniversalItem, FuzzyCompareBaseGradation>
        where TUniversalItem : IComparable<TUniversalItem>
    {
        #region IFuzzyComparer<TUniversalItem> Members

        public FuzzyCompareBaseGradation Compare(TUniversalItem first, TUniversalItem second)
        {
            switch (first.CompareTo(second))
            {
                case 1:
                    return FuzzyCompareBaseGradation.Greater;
                case 0:
                    return FuzzyCompareBaseGradation.Equal;
                default:
                    return FuzzyCompareBaseGradation.Less;
            }
        }

        #endregion
    }
}