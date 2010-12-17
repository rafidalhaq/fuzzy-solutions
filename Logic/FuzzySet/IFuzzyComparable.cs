using IGS.Fuzzy.Core.FuzzyGradation;

namespace IGS.Fuzzy.Core
{
    public interface IFuzzyComparable<in T>
    {
        FuzzyCompareGradation FuzzyCompareTo(T item);
    }
}