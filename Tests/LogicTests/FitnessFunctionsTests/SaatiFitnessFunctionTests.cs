using IGS.Fuzzy.Comparers;
using IGS.Fuzzy.FitnessFunctions;
using Xunit;

namespace FitnessFunctionsTests
{
    public class SaatiFitnessFunctionTests
    {
        [Fact]
        public void TestNormalCase()
        {
            var saati = new SaatiFitnessFunction<int>(new ExpertListBasedComparer<int>());
        }
    }
}