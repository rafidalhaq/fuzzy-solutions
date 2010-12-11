using System.Collections.Generic;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FitnessFunctions;
using Xunit;

namespace FitnessFunctionsTests
{
    public class SwitchFitnessFunctionTests
    {
        [Fact]
        public void TestSimpleInvoke()
        {
            IDictionary<int, double> dictionary = new Dictionary<int, double> {{1, 0.5}, {2, 0.6}};

            IFitnessFunction<int> fitnessFunction = new SwitchFitnessFunction<int>(dictionary);

            Assert.Equal(0.5, fitnessFunction.Invoke(1));
            Assert.Equal(0.6, fitnessFunction.Invoke(2));
        }

        [Fact]
        public void FitnessFunctionMustThrowExceptionForOutOfRangeElements()
        {
            IDictionary<int, double> dictionary = new Dictionary<int, double> { { 1, 0.5 } };

            IFitnessFunction<int> fitnessFunction = new SwitchFitnessFunction<int>(dictionary);

            Assert.Throws<FuzzySetUniversalItemsException>(() => fitnessFunction.Invoke(2));
        }
    }
}
