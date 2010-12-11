using System.Linq;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Inclusion
{
    public class SimpleInclusionOperation<T> : IInclusionOperation<T>
    {
        public bool IsIncludes(FuzzySet<T> inclusive, FuzzySet<T> included)
        {
            return inclusive.ItemsEquals(included)
                 && inclusive.UniversalItems.All(universalItem => inclusive.GetWeight(universalItem) >= included.GetWeight(universalItem));
        }
    }
}
