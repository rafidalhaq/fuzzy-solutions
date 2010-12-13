using System;
using System.Linq;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Unary.Supplement;
using TestStubs;
using Xunit;

namespace FuzzySetsOperationTests.TestUnaryOperations
{
    public class SupplementTests
    {
        [Fact]
        public void SimpleSupplementTest()
        {
            FuzzySet<int> fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();

            var simpleSupplementOperation = new SimpleSupplementOperation<int>();

            FuzzySet<int> supplement = simpleSupplementOperation.Operate(fuzzySet);

            Assert.Equal(0.2, Math.Round(supplement.GetWeight(1), 1));
            Assert.Equal(0.3, Math.Round(supplement.GetWeight(2), 1));
            Assert.Equal(2, supplement.UniversalItems.Count());
        }
    }
}