using System.Linq;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Binary.Union;
using TestStubs;
using Xunit;

namespace FuzzySetsOperationTests.TestBinaryOperations
{
    public class UnionOperationTests
    {
        [Fact]
        public void SimpleUnionOperationTests()
        {
            FuzzySet<int> fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();

            FuzzySet<int> other = FuzzySet<int>.Instance();

            other
                .Add(1)
                .Add(2)
                .SetFitnessFunction(x =>
                                        {
                                            switch (x)
                                            {
                                                case 1:
                                                    return 1;
                                                case 2:
                                                    return 0.2;
                                                default:
                                                    return -1;
                                            }
                                        });

            var unionOperation = new SimpleUnionOperation<int>();

            FuzzySet<int> union = unionOperation.Operate(fuzzySet, other);

            Assert.Equal(1, union.GetWeight(1));
            Assert.Equal(0.7, union.GetWeight(2));
            Assert.Equal(2, union.UniversalItems.Count());

            Assert.Equal(unionOperation.Operate(fuzzySet, other), unionOperation.Operate(other, fuzzySet));
        }

        [Fact]
        public void SimpleUnionMustThrowExceptionIfFuzzySetsUniversalItemsCollectionsAreDifferent()
        {
            FuzzySet<int> fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();
            FuzzySet<int> other = FuzzySetStubs.CreateSimpleIntFuzzySetWithDifferentUniversals();

            var unionOperation = new SimpleUnionOperation<int>();

            Assert.Throws<FuzzySetUniversalItemsException>(() => unionOperation.Operate(fuzzySet, other));
        }
    }
}