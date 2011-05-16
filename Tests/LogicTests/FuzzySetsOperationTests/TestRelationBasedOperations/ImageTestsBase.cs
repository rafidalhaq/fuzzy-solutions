using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FitnessFunctions;

namespace FuzzySetsOperationTests.TestRelationBasedOperations
{
    public class ImageTestsBase
    {
        private readonly IEnumerable<TestUniversals> universals = new[]
                                                                      {
                                                                          TestUniversals.X1, 
                                                                          TestUniversals.X2, 
                                                                          TestUniversals.X3,
                                                                          TestUniversals.X4
                                                                      };

        protected enum TestUniversals { X1, X2, X3, X4 }

        protected FuzzySet<TestUniversals> CreateSet(IEnumerable<double> weights)
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