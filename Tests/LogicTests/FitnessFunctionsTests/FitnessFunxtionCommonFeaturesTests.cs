using System.Collections.Generic;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FitnessFunctions;
using Xunit;

namespace FitnessFunctionsTests
{
    public class FitnessFunxtionCommonFeaturesTests
    {
        [Fact]
        public void GetMaxTests()
        {
            IDictionary<int, double> dictionary = new Dictionary<int, double> {{1, 11}, {2, 13}, {3, 12}};

            IFitnessFunction<int> fitnessFunction = new SwitchFitnessFunction<int>(dictionary);
        
            Assert.Equal(13, fitnessFunction.GetMax());
        }
    }
}