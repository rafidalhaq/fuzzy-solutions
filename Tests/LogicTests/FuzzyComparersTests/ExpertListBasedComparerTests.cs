using IGS.Fuzzy.Comparers;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.Core.FuzzyGradation;
using Xunit;

namespace FuzzyComparersTests
{
    public class ExpertListBasedComparerTests
    {
        private readonly ExpertListBasedComparer<int> comparer = new ExpertListBasedComparer<int>();

        [Fact]
        public void TestComparing()
        {
            comparer.AddPair(1, 2, FuzzyCompareGradation.AlmostEqual);

            Assert.Equal(FuzzyCompareGradation.AlmostEqual, comparer.Compare(1, 2));
        }

        [Fact]
        public void ComparingOperationIsSensitiveToPosition()
        {
            comparer.AddPair(1, 2, FuzzyCompareGradation.LittleBitGreater);

            Assert.Throws<FuzzyComparerException>(() => comparer.Compare(2, 1));
        }
    }
}