using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Inclusion
{
    public interface IInclusionOperation<T>
    {
        bool IsIncludes(FuzzySet<T> inclusive, FuzzySet<T> included);
    }
}