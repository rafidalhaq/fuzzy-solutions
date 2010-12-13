using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Binary.AlgebraicSum;
using Xunit;

namespace FuzzySetsOperationTests.TestBinaryOperations
{
    public class AlgebraicSumOperationTests
    {
        [Fact]
        public void SimpleAlgebraicOperationTest()
        {
            FuzzySet<int> firstSet = FuzzySet<int>.Instance()
                .Add(1)
                .SetFitnessFunction(x => x == 1 ? 0.5 : 777);

            FuzzySet<int> secondSet = FuzzySet<int>.Instance()
                .Add(1)
                .SetFitnessFunction(x => x == 1 ? 0.2 : 888);

            var algebraicSumOperation = new SimpleAlgebraicSumOperation<int>();

            FuzzySet<int> algebraicSum = algebraicSumOperation.Operate(firstSet, secondSet);

            Assert.Equal(0.6, algebraicSum.GetWeight(1));
        }
    }
}