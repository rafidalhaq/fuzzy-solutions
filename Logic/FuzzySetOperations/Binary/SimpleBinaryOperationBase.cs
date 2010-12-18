using System;
using System.Linq;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Binary
{
    public abstract class SimpleBinaryOperationBase<T> : SimpleOperationBase<T>, IBinaryFuzzySetOperation<T>
    {
        #region IBinaryFuzzySetOperation<T> Members

        public FuzzySet<T> Operate(FuzzySet<T> first, FuzzySet<T> second)
        {
            return OperateBase(new []{first, second});
        }

        #endregion

        protected override Func<T, double> GetFitnessFunxtion(System.Collections.Generic.IEnumerable<FuzzySet<T>> sets)
        {
            var fuzzySets = sets.ToList();

            var first = fuzzySets[0];
            var second = fuzzySets[1];

            return GetFitnessFunxtion(first, second);
        }

        protected abstract Func<T, double> GetFitnessFunxtion(FuzzySet<T> first, FuzzySet<T> second);
    }
}