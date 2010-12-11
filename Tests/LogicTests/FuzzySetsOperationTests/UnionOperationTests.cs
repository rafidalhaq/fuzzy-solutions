using System.Linq;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Union;
using TestStubs;
using Xunit;

namespace FuzzySetsOperationTests
{
    public class UnionOperationTests
    {
        [Fact]
        public void SimpleUnionOperationTests()
        {
            var fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();

            var other = new FuzzySet<int>();

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

            IUnionOperation<int> unionOperation = new SimpleUnionOperation<int>();

            var union = unionOperation.Union(fuzzySet, other);

            Assert.Equal(1, union.GetWeight(1));
            Assert.Equal(0.7, union.GetWeight(2));
            Assert.Equal(2, union.UniversalItems.Count());

            Assert.Equal(unionOperation.Union(fuzzySet, other), unionOperation.Union(other, fuzzySet));
        }

        [Fact]
        public void SimpleUnionMustThrowExceptionIfFuzzySetsUniversalItemsCollectionsAreDifferent()
        {
            var fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();
            var other = FuzzySetStubs.CreateSimpleIntFuzzySetWithDifferentUniversals();
            
            IUnionOperation<int> unionOperation = new SimpleUnionOperation<int>();

            Assert.Throws<FuzzySetUniversalItemsException>(() => unionOperation.Union(fuzzySet, other));
        }
    }
}