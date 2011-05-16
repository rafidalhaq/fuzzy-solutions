using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Unary.Supplement
{
    public class SimpleSupplementOperation<T> : IUnaryFuzzySetOperation<T>
    {
        #region IUnaryFuzzySetOperation<T> Members

        public FuzzySet<T> Operate(FuzzySet<T> fuzzySet)
        {
            FuzzySet<T> supplement = FuzzySet<T>.Instance();

            supplement.Add(fuzzySet);

            supplement.SetFitnessFunction(x => 1 - fuzzySet.FitnessFunction.Invoke(x));

            return supplement;
        }

        #endregion
    }
}