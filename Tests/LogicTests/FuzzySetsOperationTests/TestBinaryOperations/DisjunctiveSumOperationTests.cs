using System;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Binary.DisjunctiveSum;
using Xunit;

namespace FuzzySetsOperationTests.TestBinaryOperations
{
    public class DisjunctiveSumOperationTests
    {
        [Fact]
        public void SimpleDisjunctiveDifferenceOperationTest()
        {
            FuzzySet<int> firstSet = FuzzySet<int>.Instance()
                .Add(1)
                .SetFitnessFunction(x => x == 1 ? 0.2 : 777);

            FuzzySet<int> secondSet = FuzzySet<int>.Instance()
                .Add(1)
                .SetFitnessFunction(x => x == 1 ? 0.9 : 888);

            var operation = new SimpleDisjunctiveSumOperation<int>();

            FuzzySet<int> result = operation.Operate(firstSet, secondSet);

            Assert.Equal(0.8, Math.Round(result.GetWeight(1), 1));
        }
    }
}