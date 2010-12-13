using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Logical
{
    public interface ILogicalFuzzySetOperation<T>
    {
        bool Operate(FuzzySet<T> first, FuzzySet<T> second);
    }
}