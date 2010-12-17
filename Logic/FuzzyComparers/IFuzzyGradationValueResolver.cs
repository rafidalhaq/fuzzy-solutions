namespace IGS.Fuzzy.Core.FuzzyGradation
{
    public interface IFuzzyGradationValueResolver
    {
        double Resolve(FuzzyCompareGradation gradation);
    }
}