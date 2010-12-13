using System.Linq;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Binary.Intersection;
using TestStubs;
using Xunit;

namespace FuzzySetsOperationTests.TestBinaryOperations
{
    public class IntersectionOperationTests
    {
        [Fact]
        public void SimpleIntersectionTest()
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
                                                    return 0.05;
                                                case 2:
                                                    return 0.9;
                                                default:
                                                    return -1;
                                            }
                                        });

            var intersectionOperation = new SimpleIntersectionOperation<int>();

            FuzzySet<int> intersection = intersectionOperation.Operate(fuzzySet, other);

            Assert.Equal(0.05, intersection.GetWeight(1));
            Assert.Equal(0.7, intersection.GetWeight(2));
            Assert.Equal(2, intersection.UniversalItems.Count());

            Assert.Equal(intersectionOperation.Operate(fuzzySet, other), intersectionOperation.Operate(other, fuzzySet));
        }

        [Fact]
        public void SimpleIntersectionMustThrowExceptionIfFuzzySetsUniversalItemsCollectionsAreDifferent()
        {
            FuzzySet<int> fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();
            FuzzySet<int> other = FuzzySetStubs.CreateSimpleIntFuzzySetWithDifferentUniversals();

            var intersectionOperation = new SimpleIntersectionOperation<int>();

            Assert.Throws<FuzzySetUniversalItemsException>(() => intersectionOperation.Operate(fuzzySet, other));
        }
    }
}