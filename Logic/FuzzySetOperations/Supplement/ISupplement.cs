using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Supplement
{
    public interface ISupplement<T>
    {
        FuzzySet<T> Supplement(FuzzySet<T> fuzzySet);
    }
}