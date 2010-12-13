using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Logical.Inclusion;
using TestStubs;
using Xunit;

namespace FuzzySetsOperationTests.TestLogicalOperations
{
    public class InclusionOperationTests
    {
        [Fact]
        public void SimpleInclusionOperationTest()
        {
            FuzzySet<int> included = FuzzySetStubs.CreateSimpleIntFuzzySet();
            FuzzySet<int> inclusive = FuzzySet<int>.Instance();

            inclusive
                .Add(1)
                .Add(2)
                .SetFitnessFunction(x =>
                                        {
                                            switch (x)
                                            {
                                                case 1:
                                                    return 1;
                                                case 2:
                                                    return 1;
                                                default:
                                                    return 1;
                                            }
                                        });

            var operation = new SimpleInclusionOperation<int>();

            Assert.True(operation.Operate(inclusive, included));
            Assert.False(operation.Operate(included, inclusive));
        }
    }
}