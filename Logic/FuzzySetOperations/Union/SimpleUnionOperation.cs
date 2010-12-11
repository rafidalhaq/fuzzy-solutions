using System.Linq;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Union
{
    public class SimpleUnionOperation<T> : SimpleUnionIntersectionOperationBase<T>, IUnionOperation<T>
    {
        public FuzzySet<T> Union(FuzzySet<T> first, FuzzySet<T> second)
        {
            return SetOperation(first, second, "объединение", (x, y) => new[] { x, y }.Max());
        }
    }
}