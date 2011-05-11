using IGS.Fuzzy.Comparers;
using IGS.Fuzzy.Core.FuzzyGradation;
using IGS.Fuzzy.FitnessFunctions;
using Xunit;

namespace FuzzyComparersTests
{
    public class TestFuzzyGradationResolvers
    {
        [Fact]
        public void TestOrderingGradationValueResolver()
        {
            IFuzzyGradationValueResolver resolver = new FuzzyOrderingGradationValueResolver();

            Assert.Equal(0, resolver.Resolve(FuzzyCompareGradation.Equal));
            Assert.Equal(0, resolver.Resolve(FuzzyCompareGradation.BetweenEqualAndAlmostEqual));
            Assert.Equal(0.25, resolver.Resolve(FuzzyCompareGradation.AlmostEqual));
            Assert.Equal(0.25, resolver.Resolve(FuzzyCompareGradation.BetweenAlmostEqualAndLittleBitGreater));
            Assert.Equal(0.5, resolver.Resolve(FuzzyCompareGradation.LittleBitGreater));
            Assert.Equal(0.5, resolver.Resolve(FuzzyCompareGradation.BetweenLittleBitGreaterAndGreater));
            Assert.Equal(0.75, resolver.Resolve(FuzzyCompareGradation.Greater));
            Assert.Equal(0.75, resolver.Resolve(FuzzyCompareGradation.BetweenGreaterAndMuchGreater));
            Assert.Equal(1, resolver.Resolve(FuzzyCompareGradation.MuchGreater));
            Assert.Equal(-1, resolver.Resolve(FuzzyCompareGradation.Less));
        }

        [Fact]
        public void TestSaatiGradationValueResolver()
        {
            IFuzzyGradationValueResolver resolver = new SaatiOrderingGradationValueResolver();

            Assert.Equal(1, resolver.Resolve(FuzzyCompareGradation.Equal));
            Assert.Equal(2, resolver.Resolve(FuzzyCompareGradation.BetweenEqualAndAlmostEqual));
            Assert.Equal(3, resolver.Resolve(FuzzyCompareGradation.AlmostEqual));
            Assert.Equal(4, resolver.Resolve(FuzzyCompareGradation.BetweenAlmostEqualAndLittleBitGreater));
            Assert.Equal(5, resolver.Resolve(FuzzyCompareGradation.LittleBitGreater));
            Assert.Equal(6, resolver.Resolve(FuzzyCompareGradation.BetweenLittleBitGreaterAndGreater));
            Assert.Equal(7, resolver.Resolve(FuzzyCompareGradation.Greater));
            Assert.Equal(8, resolver.Resolve(FuzzyCompareGradation.BetweenGreaterAndMuchGreater));
            Assert.Equal(9, resolver.Resolve(FuzzyCompareGradation.MuchGreater));
            Assert.Equal(-1, resolver.Resolve(FuzzyCompareGradation.Less));
        }
    }
}