using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Unary
{
    public interface IUnaryFuzzySetOperation<T>
    {
        FuzzySet<T> Operate(FuzzySet<T> fuzzySet);
    }
}