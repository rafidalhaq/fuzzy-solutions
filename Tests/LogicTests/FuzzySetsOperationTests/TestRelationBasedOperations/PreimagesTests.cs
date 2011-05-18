using System;
using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FitnessFunctions;
using IGS.Fuzzy.FuzzySetOperations.RelationBased;
using Xunit;

namespace FuzzySetsOperationTests.TestRelationBasedOperations
{
    public class PreimagesTests
    {
        private readonly IEnumerable<TestUniversals> universals = new[]
                                                                      {
                                                                          TestUniversals.X1, 
                                                                          TestUniversals.X2
                                                                      };

        private enum TestUniversals { X1, X2 }

        private FuzzySet<TestUniversals> CreateSet(IEnumerable<double> weights)
        {
            var dictionary = new Dictionary<TestUniversals, double>
                                 {
                                     {TestUniversals.X1, weights.ElementAt(0)}, 
                                     {TestUniversals.X2, weights.ElementAt(1)}, 
                                 };

            return FuzzySet<TestUniversals>
                .Instance()
                .Add(universals)
                .SetFitnessFunction(new SwitchFitnessFunction<TestUniversals>(dictionary));
        }

        private IEnumerable<FuzzySet<TestUniversals>> CreateRelation()
        {
            return new[]
                       {
                           CreateSet(new[] {0.9, 0.6}),
                           CreateSet(new[] {0.1, 0.5}),
                           CreateSet(new[] {0.2, 0.5})
                       };
        }

        private static FuzzySet<FuzzySet<TestUniversals>> CreateImage(IEnumerable<FuzzySet<TestUniversals>> relation)
        {
            var setFromRelation1 = relation.ElementAt(0);
            var setFromRelation2 = relation.ElementAt(1);
            var setFromRelation3 = relation.ElementAt(2);

            return FuzzySet<FuzzySet<TestUniversals>>
                .Instance()
                .Add(new[] { setFromRelation1, setFromRelation2, setFromRelation3 })
                .SetFitnessFunction(x =>
                {
                    if (x.Equals(setFromRelation1)) return 0.9;
                    if (x.Equals(setFromRelation2)) return 0.1;
                    if (x.Equals(setFromRelation3)) return 0.2;
                    throw new Exception();
                });
        }

        [Fact]
        public void TestPreimageOperationClassA()
        {
            var relation = CreateRelation();
            var image = CreateImage(relation);

            var preimageClassA = new PreimageOperationClassA<TestUniversals>().Operate(image, relation);

            Assert.Equal(1, preimageClassA.GetWeight(TestUniversals.X1));
            Assert.Equal(0.1, preimageClassA.GetWeight(TestUniversals.X2));
        }

        [Fact]
        public void TestPreimageOperationClassB()
        {
            var relation = CreateRelation();
            var image = CreateImage(relation);

            var preimageClassA = new PreimageOperationClassB<TestUniversals>().Operate(image, relation);

            Assert.Equal(1, preimageClassA.GetWeight(TestUniversals.X1));
            Assert.Equal(0.6, preimageClassA.GetWeight(TestUniversals.X2));
        }

        [Fact]
        public void TestPreimageOperationClassC()
        {
            var relation = CreateRelation();
            var image = CreateImage(relation);

            var preimageClassA = new PreimageOperationClassC<TestUniversals>().Operate(image, relation);

            Assert.Equal(0.9, preimageClassA.GetWeight(TestUniversals.X1));
            Assert.Equal(0.6, preimageClassA.GetWeight(TestUniversals.X2));
        }
    }
}