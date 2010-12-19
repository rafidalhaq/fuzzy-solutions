namespace IGS.Fuzzy.Core
{
    public interface IFitnessFunction<T>
    {
        FuzzySet<T> ParentSet { set; }
        double Invoke(T item);
        double GetMax();
    }
}