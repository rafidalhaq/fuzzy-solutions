using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Inclusion;
using TestStubs;
using Xunit;

namespace FuzzySetsOperationTests
{
    public class InclusionOperationTests
    {
        [Fact]
        public void SimpleInclusionOperationTest()
        {
            var included = FuzzySetStubs.CreateSimpleIntFuzzySet();
            var inclusive = new FuzzySet<int>();

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

            IInclusionOperation<int> operation = new SimpleInclusionOperation<int>();

            Assert.True(operation.IsIncludes(inclusive, included));
            Assert.False(operation.IsIncludes(included, inclusive));
        }
    }
}
