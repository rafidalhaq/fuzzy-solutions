using IGS.Fuzzy.Core;
using IGS.Fuzzy.Core.FuzzyGradation;

namespace IGS.Fuzzy.Comparers
{
    public class ElementsComparingBasedComparer<T> : IFuzzyComparer<T>
        where T : IFuzzyComparable<T>
    {
        #region IFuzzyComparer<T> Members

        public FuzzyCompareGradation Compare(T first, T second)
        {
            return first.FuzzyCompareTo(second);
        }

        #endregion
    }
}