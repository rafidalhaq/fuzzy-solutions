using System.Collections.Generic;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Multiple
{
    public abstract class SimpleMultipleOperationBase<T> : SimpleOperationBase<T>, IMultipleFuzzySetOperation<T>
    {
        #region IBinaryFuzzySetOperation<T> Members

        public FuzzySet<T> Operate(FuzzySet<T> first, FuzzySet<T> second)
        {
            return Operate(new[] {first, second});
        }

        #endregion

        public FuzzySet<T> Operate(IEnumerable<FuzzySet<T>> sets)
        {
            return OperateBase(sets);
        }
    }
}