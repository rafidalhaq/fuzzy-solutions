using IGS.Fuzzy.Core.FuzzyGradation;

namespace IGS.Fuzzy.Comparers
{
    public interface IFuzzyComparer<in T>
    {
        FuzzyCompareGradation Compare(T first, T second);
    }
}