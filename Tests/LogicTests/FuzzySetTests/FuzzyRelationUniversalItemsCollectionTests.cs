using System;
using System.Linq;
using IGS.Fuzzy.Core;
using Xunit;

namespace FuzzySetTests
{
    public class FuzzyRelationUniversalItemsCollectionTests
    {
        [Fact]
        public void TestFuzzyRelationUniversalItemsCollection()
        {
            FuzzySet<int> fuzzySetFirst = TestStubs.FuzzySetStubs.CreateSimpleIntFuzzySet();
            FuzzySet<int> fuzzySetSecond = TestStubs.FuzzySetStubs.CreateSimpleIntFuzzySetWithDifferentUniversals();

            var fuzzyRelationUniversalItemsCollection = new FuzzyRelationUniversalItemsCollection<int>(fuzzySetFirst, fuzzySetSecond)
                                                            {new Tuple<int, int>(4, 5)};

            Assert.Equal(5, fuzzyRelationUniversalItemsCollection.Count());
            Assert.True(fuzzyRelationUniversalItemsCollection.Contains(new Tuple<int, int>(1, 1)));
            Assert.True(fuzzyRelationUniversalItemsCollection.Contains(new Tuple<int, int>(1, 3)));
            Assert.True(fuzzyRelationUniversalItemsCollection.Contains(new Tuple<int, int>(2, 1)));
            Assert.True(fuzzyRelationUniversalItemsCollection.Contains(new Tuple<int, int>(2, 3)));
            Assert.True(fuzzyRelationUniversalItemsCollection.Contains(new Tuple<int, int>(4, 5)));
        }
    }
}