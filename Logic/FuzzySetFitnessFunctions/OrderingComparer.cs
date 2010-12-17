using System.Collections.Generic;
using IGS.Fuzzy.Comparers;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.Core.FuzzyGradation;

namespace IGS.Fuzzy.FitnessFunctions
{
    public class OrderingComparer<T> : IComparer<T>
    {
        private readonly IFuzzyComparer<T> fuzzyComparer;

        public OrderingComparer(IFuzzyComparer<T> fuzzyComparer)
        {
            this.fuzzyComparer = fuzzyComparer;
        }

        #region IComparer<T> Members

        public int Compare(T x, T y)
        {
            FuzzyCompareGradation fuzzyCompareResult = fuzzyComparer.Compare(x, y);

            if (fuzzyCompareResult == FuzzyCompareGradation.Less)
                return -1;

            if (fuzzyCompareResult == FuzzyCompareGradation.Equal)
                return 0;

            return 1;
        }

        #endregion
    }
}