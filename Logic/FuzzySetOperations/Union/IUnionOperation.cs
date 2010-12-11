using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Union
{
    public interface IUnionOperation<T>
    {
        FuzzySet<T> Union(FuzzySet<T> first, FuzzySet<T> second);
    }
}