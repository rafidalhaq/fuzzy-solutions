namespace IGS.Fuzzy.Core
{
    public interface IFitnessFunction<T>
    {
        double Invoke(T item);

        FuzzySet<T> ParentSet { set; }
    }
}