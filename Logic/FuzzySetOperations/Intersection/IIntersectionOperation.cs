using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Intersection
{
    public interface IIntersectionOperation<T>
    {
        FuzzySet<T> Intersect(FuzzySet<T> first, FuzzySet<T> second);
    }
}