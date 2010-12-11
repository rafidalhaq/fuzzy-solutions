using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.Comparers
{
    public class ElementsComparingBasedComparer<T> : IFuzzyComparer<T> 
        where T : IFuzzyComparable<T>
    {
        public FuzzyCompareGradation Compare(T first, T second)
        {
            return first.FuzzyCompareTo(second);
        }
    }
}