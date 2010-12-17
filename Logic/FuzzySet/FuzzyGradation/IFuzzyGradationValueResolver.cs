namespace IGS.Fuzzy.Core.FuzzyGradation
{
    public interface IFuzzyGradationValueResolver<in T>
    {
        double Resolve(T gradation);
    }
}