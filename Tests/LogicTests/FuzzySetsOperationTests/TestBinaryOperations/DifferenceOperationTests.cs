using System;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Binary.Difference;
using Xunit;

namespace FuzzySetsOperationTests.TestBinaryOperations
{
    public class DifferenceOperationTests
    {
        [Fact]
        public void SimpleDifferenceOperationTest()
        {
            FuzzySet<int> firstSet = FuzzySet<int>.Instance()
                .Add(1)
                .SetFitnessFunction(x => x == 1 ? 0.2 : 777);

            FuzzySet<int> secondSet = FuzzySet<int>.Instance()
                .Add(1)
                .SetFitnessFunction(x => x == 1 ? 0.9 : 888);

            var operation = new SimpleDifferenceOperation<int>();

            FuzzySet<int> result = operation.Operate(firstSet, secondSet);

            Assert.Equal(0.1, Math.Round(result.GetWeight(1), 1));
        }
    }
}