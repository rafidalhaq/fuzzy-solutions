using System.Linq;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations;
using IGS.Fuzzy.FuzzySetOperations.Multiple.Union;
using TestStubs;
using Xunit;

namespace FuzzySetsOperationTests.TestMultipleOperations
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
        public void SimpleUnionMultipleTest()
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

            var algebraicCompositionOperation = new SimpleUnionOperation<int>();

            FuzzySet<int> algebraicComposition = algebraicCompositionOperation.Operate(new[] { firstSet, secondSet, thirdSet });

            Assert.Equal(0.5, algebraicComposition.GetWeight(1));
        }

        [Fact]
        public void SimpleUnionMustThrowExceptionIfFuzzySetsUniversalItemsCollectionsAreDifferent()
        {
            FuzzySet<int> fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();
            FuzzySet<int> other = FuzzySetStubs.CreateSimpleIntFuzzySetWithDifferentUniversals();

            var unionOperation = new SimpleUnionOperation<int>();

            Assert.Throws<FuzzySetOperationException>(() => unionOperation.Operate(fuzzySet, other));
        }
    }
}