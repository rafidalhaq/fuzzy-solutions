using System;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Unary.Supplement;
using Xunit;

namespace FuzzySetsOperationTests.TestUnaryOperations
{
    public class CommonUnaryFeaturesTests
    {
        [Fact]
        public void ResultShouldNotDependOnOriginalSetUniversalItems()
        {
            FuzzySet<int> set = FuzzySet<int>
                .Instance()
                .Add(1)
                .SetFitnessFunction(x => 0.8);

            var operation = new SimpleSupplementOperation<int>();

            FuzzySet<int> result = operation.Operate(set);

            result.Add(2);

            Assert.Equal(0.2, Math.Round(result.GetWeight(2), 1));
        }
    }
}