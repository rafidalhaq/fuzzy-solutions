using System.Collections.Generic;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations;
using IGS.Fuzzy.FuzzySetOperations.Multiple.AlgebraicComposition;
using Xunit;

namespace FuzzySetsOperationTests.TestMultipleOperations
{
    public class CommonMultipleFeaturesTests
    {
        [Fact]
        public void TestSimpleBaseMultipleOperationEmptySetsCollection()
        {
            var simpleMultipleOperation = new SimpleAlgebraicCompositionOperation<int>();

            Assert.Throws<FuzzySetOperationException>(() => simpleMultipleOperation.Operate(new List<FuzzySet<int>>()));
        }
    }
}