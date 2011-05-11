using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Multiple.Intersection;
using Xunit;

namespace FuzzySetsOperationTests.TestBinaryOperations
{
    public class CommonBinaryFeaturesTests
    {
        [Fact]
        public void ResultShouldNotDependOnOriginalSetsUniversalItems()
        {
            FuzzySet<int> set1 = FuzzySet<int>
                .Instance()
                .Add(1)
                .SetFitnessFunction(x => 2);

            FuzzySet<int> set2 = FuzzySet<int>
                .Instance()
                .Add(1)
                .SetFitnessFunction(x => 3);

            var operation = new SimpleIntersectionOperation<int>();

            FuzzySet<int> result = operation.Operate(set1, set2);

            result.Add(2);

            Assert.Equal(2, result.GetWeight(2));
        }
    }
}