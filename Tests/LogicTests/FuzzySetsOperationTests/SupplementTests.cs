using System;
using System.Linq;
using IGS.Fuzzy.FuzzySetOperations.Supplement;
using TestStubs;
using Xunit;

namespace FuzzySetsOperationTests
{
    public class SupplementTests
    {
        [Fact]
        public void SimpleSupplementTest()
        {
            var fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();

            ISupplement<int> supplement = new SimpleSupplement<int>();

            var suppliment = supplement.Supplement(fuzzySet);

            Assert.Equal(0.2, Math.Round(suppliment.GetWeight(1), 1));
            Assert.Equal(0.3, Math.Round(suppliment.GetWeight(2), 1));
            Assert.Equal(2, suppliment.UniversalItems.Count());
        }
    }
}