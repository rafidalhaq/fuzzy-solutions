using System.Linq;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations;
using IGS.Fuzzy.FuzzySetOperations.Binary.Intersection;
using TestStubs;
using Xunit;

namespace FuzzySetsOperationTests.TestMultipleOperations
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
        public void SimpleIntersectionMultipleTest()
        {
            FuzzySet<int> firstSet = FuzzySet<int>.Instance()
                .Add(1)
                .SetFitnessFunction(x => x == 1 ? 0.5 : 777);

            FuzzySet<int> secondSet = FuzzySet<int>.Instance()
                .Add(1)
                .SetFitnessFunction(x => x == 1 ? 0.2 : 888);

            FuzzySet<int> thirdSet = FuzzySet<int>.Instance()
                .Add(1)
                .SetFitnessFunction(x => x == 1 ? 0.1 : 888);

            var algebraicCompositionOperation = new SimpleIntersectionOperation<int>();

            FuzzySet<int> algebraicComposition =
                algebraicCompositionOperation.Operate(new[] {firstSet, secondSet, thirdSet});

            Assert.Equal(0.1, algebraicComposition.GetWeight(1));
        }

        [Fact]
        public void SimpleIntersectionMustThrowExceptionIfFuzzySetsUniversalItemsCollectionsAreDifferent()
        {
            FuzzySet<int> fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();
            FuzzySet<int> other = FuzzySetStubs.CreateSimpleIntFuzzySetWithDifferentUniversals();

            var intersectionOperation = new SimpleIntersectionOperation<int>();

            Assert.Throws<FuzzySetOperationException>(() => intersectionOperation.Operate(fuzzySet, other));
        }
    }
}