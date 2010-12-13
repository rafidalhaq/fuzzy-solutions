using IGS.Fuzzy.Core;
using Moq;
using Xunit;

namespace FuzzyComparersTests
{
    public class CompareToTests
    {
        [Fact]
        public void TestSimpleComparerWithFuzzyComparableItems()
        {
            var fuzzyComparableItem1 = new Mock<IFuzzyComparable<object>>();
            var fuzzyComparableItem2 = new Mock<IFuzzyComparable<object>>();

            fuzzyComparableItem1.Setup(x => x.FuzzyCompareTo(fuzzyComparableItem2.Object))
                .Returns(FuzzyCompareGradation.LittleBitGreater);

            Assert.Equal(FuzzyCompareGradation.LittleBitGreater,
                         fuzzyComparableItem1.Object.FuzzyCompareTo(fuzzyComparableItem2.Object));
        }
    }
}