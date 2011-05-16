using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FitnessFunctions;
using IGS.Fuzzy.FuzzySetOperations.Multiple.Intersection;
using IGS.Fuzzy.FuzzySetOperations.RelationBased;
using Xunit;

namespace FuzzySetsOperationTests.TestRelationBasedOperations
{
    public class DirectImageTests
    {
        private enum TestUniversals { X1, X2, X3, X4 }

        private readonly IEnumerable<TestUniversals> universals = new[]
                                                             {
                                                                 TestUniversals.X1, 
                                                                 TestUniversals.X2, 
                                                                 TestUniversals.X3,
                                                                 TestUniversals.X4
                                                             };

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

        private FuzzySet<TestUniversals> CreateSet(IEnumerable<double> weights)
        {
            var dictionary = new Dictionary<TestUniversals, double>
                                 {
                                     {TestUniversals.X1, weights.ElementAt(0)}, 
                                     {TestUniversals.X2, weights.ElementAt(1)}, 
                                     {TestUniversals.X3, weights.ElementAt(2)}, 
                                     {TestUniversals.X4, weights.ElementAt(3)}, 
                                 };

            return FuzzySet<TestUniversals>
                .Instance()
                .Add(universals)
                .SetFitnessFunction(new SwitchFitnessFunction<TestUniversals>(dictionary));
        }
    }
}
