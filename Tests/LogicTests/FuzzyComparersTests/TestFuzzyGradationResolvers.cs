using IGS.Fuzzy.Core.FuzzyGradation;
using Xunit;

namespace FuzzyComparersTests
{
    public class TestFuzzyGradationResolvers
    {
        [Fact]
        public void TestOrderingGradationValueResolver()
        {
            IFuzzyGradationValueResolver<FuzzyCompareGradation> resolver = new FuzzyOrderingGradationValueResolver();

            Assert.Equal(0, resolver.Resolve(FuzzyCompareGradation.Equal));
            Assert.Equal(0.25, resolver.Resolve(FuzzyCompareGradation.AlmostEqual));
            Assert.Equal(0.5, resolver.Resolve(FuzzyCompareGradation.LittleBitGreater));
            Assert.Equal(0.75, resolver.Resolve(FuzzyCompareGradation.Greater));
            Assert.Equal(1, resolver.Resolve(FuzzyCompareGradation.MuchGreater));
            Assert.Equal(-1, resolver.Resolve(FuzzyCompareGradation.Less));
        }
    }
}