using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Binary.AlgebraicComposition;
using Xunit;

namespace FuzzySetsOperationTests.TestBinaryOperations
{
    public class AlgebraicCompositionOperationTests
    {
        [Fact]
        public void SimpleAlgebraicCompositionOperationTest()
        {
            FuzzySet<int> firstSet = FuzzySet<int>.Instance()
                .Add(1)
                .SetFitnessFunction(x => x == 1 ? 0.5 : 777);

            FuzzySet<int> secondSet = FuzzySet<int>.Instance()
                .Add(1)
                .SetFitnessFunction(x => x == 1 ? 0.2 : 888);

            var algebraicCompositionOperation = new SimpleAlgebraicCompositionOperation<int>();

            FuzzySet<int> algebraicComposition = algebraicCompositionOperation.Operate(firstSet, secondSet);

            Assert.Equal(0.1, algebraicComposition.GetWeight(1));
        }
    }
}