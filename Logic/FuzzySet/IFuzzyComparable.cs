namespace IGS.Fuzzy.Core
{
    public interface IFuzzyComparable<T>
    {
        FuzzyCompareGradation FuzzyCompareTo(T item);
    }
}