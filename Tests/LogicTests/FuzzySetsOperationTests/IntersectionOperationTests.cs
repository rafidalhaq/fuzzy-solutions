using System.Linq;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Intersection;
using TestStubs;
using Xunit;

namespace FuzzySetsOperationTests
{
    public class IntersectionOperationTests
    {
        [Fact]
        public void SimpleIntersectionTest()
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
                            return 0.05;
                        case 2:
                            return 0.9;
                        default:
                            return -1;
                    }
                });

            IIntersectionOperation<int> intersectionOperation = new SimpleIntersectionOperation<int>();

            var intersection = intersectionOperation.Intersect(fuzzySet, other);

            Assert.Equal(0.05, intersection.GetWeight(1));
            Assert.Equal(0.7, intersection.GetWeight(2));
            Assert.Equal(2, intersection.UniversalItems.Count());

            Assert.Equal(intersectionOperation.Intersect(fuzzySet, other), intersectionOperation.Intersect(other, fuzzySet));
        }

        [Fact]
        public void SimpleIntersectionMustThrowExceptionIfFuzzySetsUniversalItemsCollectionsAreDifferent()
        {
            var fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();
            var other = FuzzySetStubs.CreateSimpleIntFuzzySetWithDifferentUniversals();

            IIntersectionOperation<int> intersectionOperation = new SimpleIntersectionOperation<int>();

            Assert.Throws<FuzzySetUniversalItemsException>(() => intersectionOperation.Intersect(fuzzySet, other));
        }
    }
}