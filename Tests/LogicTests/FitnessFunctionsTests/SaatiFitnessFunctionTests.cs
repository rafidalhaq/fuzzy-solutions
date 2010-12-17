using System;
using IGS.Fuzzy.Comparers;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.Core.FuzzyGradation;
using IGS.Fuzzy.FitnessFunctions;
using Xunit;

namespace FitnessFunctionsTests
{
    public class SaatiFitnessFunctionTests
    {
        [Fact]
        public void TestNormalCase()
        {
            var expertListBasedComparer = new ExpertListBasedComparer<int>();
            expertListBasedComparer.AddPair(1, 1, FuzzyCompareGradation.Equal);
            expertListBasedComparer.AddPair(2, 2, FuzzyCompareGradation.Equal);
            expertListBasedComparer.AddPair(3, 3, FuzzyCompareGradation.Equal);
            expertListBasedComparer.AddPair(4, 4, FuzzyCompareGradation.Equal);
            expertListBasedComparer.AddPair(1, 2, FuzzyCompareGradation.LittleBitGreater);
            expertListBasedComparer.AddPair(1, 3, FuzzyCompareGradation.BetweenLittleBitGreaterAndGreater);
            expertListBasedComparer.AddPair(1, 4, FuzzyCompareGradation.Greater);
            expertListBasedComparer.AddPair(2, 3, FuzzyCompareGradation.BetweenAlmostEqualAndLittleBitGreater);
            expertListBasedComparer.AddPair(2, 4, FuzzyCompareGradation.BetweenLittleBitGreaterAndGreater);
            expertListBasedComparer.AddPair(3, 4, FuzzyCompareGradation.BetweenAlmostEqualAndLittleBitGreater);
            expertListBasedComparer.AddPair(2, 1, FuzzyCompareGradation.Less);
            expertListBasedComparer.AddPair(3, 1, FuzzyCompareGradation.Less);
            expertListBasedComparer.AddPair(3, 2, FuzzyCompareGradation.Less);
            expertListBasedComparer.AddPair(4, 1, FuzzyCompareGradation.Less);
            expertListBasedComparer.AddPair(4, 2, FuzzyCompareGradation.Less);
            expertListBasedComparer.AddPair(4, 3, FuzzyCompareGradation.Less);

            var saati = new SaatiFitnessFunction<int>(expertListBasedComparer);

            FuzzySet<int> fuzzySet = FuzzySet<int>.Instance();

            fuzzySet
                .Add(1)
                .Add(2)
                .Add(3)
                .Add(4)
                .SetFitnessFunction(saati);

            Assert.Equal(0.69, Math.Round(fuzzySet.GetWeight(1), 2));
            Assert.Equal(0.16, Math.Round(fuzzySet.GetWeight(2), 2));
            Assert.Equal(0.09, Math.Round(fuzzySet.GetWeight(3), 2));
            Assert.Equal(0.06, Math.Round(fuzzySet.GetWeight(4), 2));
        }
    }
}