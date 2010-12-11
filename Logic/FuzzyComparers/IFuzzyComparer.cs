using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.Comparers
{
    public interface IFuzzyComparer<in T>
    {
        FuzzyCompareGradation Compare(T first, T second);
    }
}