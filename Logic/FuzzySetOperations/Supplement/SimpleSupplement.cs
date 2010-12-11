using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Supplement
{
    public class SimpleSupplement<T> : ISupplement<T>
    {
        public FuzzySet<T> Supplement(FuzzySet<T> fuzzySet)
        {
            var supplement = new FuzzySet<T>();

            supplement.Add(fuzzySet);

            supplement.SetFitnessFunction(x => 1 - fuzzySet.GetWeight(x));

            return supplement;
        }
    }
}