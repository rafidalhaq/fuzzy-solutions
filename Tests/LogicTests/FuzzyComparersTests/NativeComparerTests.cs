using IGS.Fuzzy.Comparers;
using IGS.Fuzzy.Core;
using Xunit;

namespace FuzzyComparersTests
{
    public class NativeComparerTests
    {
        [Fact]
        public void TestNativeComparer()
        {
            IFuzzyComparer<int> fuzzyComparer = new NativeComparer<int>();

            FuzzyCompareGradation shouldBeLess = fuzzyComparer.Compare(3, 4);
            FuzzyCompareGradation shouldBeGreater = fuzzyComparer.Compare(4, 3);
            FuzzyCompareGradation shouldBeEqual = fuzzyComparer.Compare(4, 4);

            Assert.Equal(FuzzyCompareGradation.Less, shouldBeLess);
            Assert.Equal(FuzzyCompareGradation.Greater, shouldBeGreater);
            Assert.Equal(FuzzyCompareGradation.Equal, shouldBeEqual);
        }
    }
}