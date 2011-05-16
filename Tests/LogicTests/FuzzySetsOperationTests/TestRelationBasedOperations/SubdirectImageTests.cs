using IGS.Fuzzy.FuzzySetOperations.RelationBased;
using Xunit;

namespace FuzzySetsOperationTests.TestRelationBasedOperations
{
    public class SubdirectImageTests : ImageTestsBase
    {
        [Fact]
        public void TestSimpleSubdirectImageOperation()
        {
            var fuzzySet = CreateSet(new[] { 0.2, 0.3, 0.8, 0.9 });

            var setForRelation1 = CreateSet(new[] { 0.1, 0.8, 0.3, 0 });
            var setForRelation2 = CreateSet(new[] { 0.4, 0.7, 0.1, 0.6 });
            var setForRelation3 = CreateSet(new[] { 0.3, 0.4, 0.8, 0.5 });
            var setForRelation4 = CreateSet(new[] { 0.5, 0.4, 0, 0.4 });

            var relation = new[] { setForRelation1, setForRelation2, setForRelation3, setForRelation4 };

            var directImage = new SubdirectImageOperation<TestUniversals>().Operate(fuzzySet, relation);

            Assert.Equal(0, directImage.GetWeight(setForRelation1));
            Assert.Equal(0.1, directImage.GetWeight(setForRelation2));
            Assert.Equal(0.5, directImage.GetWeight(setForRelation3));
            Assert.Equal(0.0, directImage.GetWeight(setForRelation4));
        }
    }
}