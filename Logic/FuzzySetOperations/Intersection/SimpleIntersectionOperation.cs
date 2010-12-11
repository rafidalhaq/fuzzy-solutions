using System.Linq;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Intersection
{
    public class SimpleIntersectionOperation<T> : SimpleUnionIntersectionOperationBase<T>, IIntersectionOperation<T>
    {
        public FuzzySet<T> Intersect(FuzzySet<T> first, FuzzySet<T> second)
        {
            return SetOperation(first, second, "пересечение", (x, y) => new[] { x, y }.Min());
        }
    }
}