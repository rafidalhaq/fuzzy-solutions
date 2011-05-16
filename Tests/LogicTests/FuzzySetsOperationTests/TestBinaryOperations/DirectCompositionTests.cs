using System;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Binary.AlgebraicSum;
using IGS.Fuzzy.FuzzySetOperations.Binary.DirectComposition;
using Xunit;

namespace FuzzySetsOperationTests.TestBinaryOperations
{
    public class DirectCompositionTests
    {
        [Fact]
        public void TestDirectComposition()
        {
            FuzzySet<int> firstSet = FuzzySet<int>.Instance()
                .Add(1)
                .Add(2)
                .Add(3)
                .SetFitnessFunction(x =>
                                        {
                                            switch (x)
                                            {
                                                case 1:
                                                    return 0.1;
                                                case 2:
                                                    return 0.2;
                                                default:
                                                    return 0.3;
                                            }
                                        });

            FuzzySet<int> secondSet = FuzzySet<int>.Instance()
                .Add(4)
                .Add(5)
                .Add(6)
                .SetFitnessFunction(x =>
                {
                    switch (x)
                    {
                        case 4:
                            return 0.4;
                        case 5:
                            return 0.3;
                        default:
                            return 0.2;
                    }
                });

            var directComposition = new DirectComposition<int>();

            FuzzySet<Tuple<int, int>> algebraicSum = directComposition.Operate(firstSet, secondSet);

            Assert.Equal(0.1, algebraicSum.GetWeight(new Tuple<int, int>(1, 4)));
            Assert.Equal(0.2, algebraicSum.GetWeight(new Tuple<int, int>(2, 5)));
            Assert.Equal(0.2, algebraicSum.GetWeight(new Tuple<int, int>(3, 6)));
        }
    }
}