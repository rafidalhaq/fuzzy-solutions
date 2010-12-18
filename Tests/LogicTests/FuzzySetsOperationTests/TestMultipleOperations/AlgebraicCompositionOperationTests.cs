using System;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Multiple.AlgebraicComposition;
using Xunit;

namespace FuzzySetsOperationTests.TestMultipleOperations
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

        [Fact]
        public void SimpleAlgebraicCompositionOnSingleSetTest()
        {
            FuzzySet<int> firstSet = FuzzySet<int>.Instance()
                .Add(1)
                .SetFitnessFunction(x => x == 1 ? 0.5 : 777);

            var algebraicCompositionOperation = new SimpleAlgebraicCompositionOperation<int>();

            FuzzySet<int> algebraicComposition = algebraicCompositionOperation.Operate(new[]{ firstSet});

            Assert.Equal(0.5, algebraicComposition.GetWeight(1));
        }

        [Fact]
        public void SimpleAlgebraicCompositionOperationMultipleTest()
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

            var algebraicCompositionOperation = new SimpleAlgebraicCompositionOperation<int>();

            FuzzySet<int> algebraicComposition = algebraicCompositionOperation.Operate(new[]{ firstSet, secondSet, thirdSet});

            Assert.Equal(0.01, Math.Round(algebraicComposition.GetWeight(1), 2));
        }
    }
}