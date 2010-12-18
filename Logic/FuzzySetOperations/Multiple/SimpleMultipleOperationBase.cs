using System.Collections.Generic;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Multiple
{
    public abstract class SimpleMultipleOperationBase<T> : SimpleOperationBase<T>, IMultipleFuzzySetOperation<T>
    {
        #region IMultipleFuzzySetOperation<T> Members

        public FuzzySet<T> Operate(FuzzySet<T> first, FuzzySet<T> second)
        {
            return Operate(new[] {first, second});
        }

        public FuzzySet<T> Operate(IEnumerable<FuzzySet<T>> sets)
        {
            return OperateBase(sets);
        }

        #endregion
    }
}