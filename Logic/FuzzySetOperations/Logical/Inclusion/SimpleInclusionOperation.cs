using System.Linq;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Logical.Inclusion
{
    public class SimpleInclusionOperation<T> : ILogicalFuzzySetOperation<T>
    {
        #region ILogicalFuzzySetOperation<T> Members

        public bool Operate(FuzzySet<T> inclusive, FuzzySet<T> included)
        {
            return inclusive.ItemsEquals(included)
                   &&
                   inclusive.UniversalItems.All(
                       universalItem => inclusive.GetWeight(universalItem) >= included.GetWeight(universalItem));
        }

        #endregion
    }
}