using IGS.Fuzzy.FuzzySetOperations.Multiple.Intersection;
using IGS.Fuzzy.FuzzySetOperations.RelationBased;
using Xunit;

namespace FuzzySetsOperationTests.TestRelationBasedOperations
{
    public class DirectImageTests : ImageTestsBase
    {
        [Fact]
        public void TestSimpleDirectImageOperation()
        {
            var fuzzySet = CreateSet(new[] {0, 1, 0.2, 0.5});

            var setForRelation1 = CreateSet(new[] {0.8, 1, 0.2, 0.4});
            var setForRelation2 = CreateSet(new[] {0.6, 0, 0, 0});
            var setForRelation3 = CreateSet(new[] { 0.4, 0.2, 0.9, 0.4 });

            var relation = new[] {setForRelation1, setForRelation2, setForRelation3};

            var directImage = new DirectImageOperation<TestUniversals>(new SimpleIntersectionOperation<TestUniversals>()).Operate(fuzzySet, relation);

            Assert.Equal(1, directImage.GetWeight(setForRelation1));
            Assert.Equal(0, directImage.GetWeight(setForRelation2));
            Assert.Equal(0.4, directImage.GetWeight(setForRelation3));
        }
    }
}
