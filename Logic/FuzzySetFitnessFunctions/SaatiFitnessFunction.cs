using System;
using System.Collections.Generic;
using IGS.Fuzzy.Comparers;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FitnessFunctions
{
    public class SaatiFitnessFunction<T> : FitnessFunctionWithFitnessListBuilding<T>
    {
        private readonly IDictionary<FuzzyCompareGradation, double> gradations = new Dictionary<FuzzyCompareGradation, double>();

        public SaatiFitnessFunction(IFuzzyComparer<T> comparer) : base(comparer)
        {
            InitializeGradationDecryptor();
        }

        private void InitializeGradationDecryptor()
        {
            gradations.Add(FuzzyCompareGradation.Equal, 1);
            gradations.Add(FuzzyCompareGradation.BetweenEqualAndAlmostEqual, 2);
            gradations.Add(FuzzyCompareGradation.AlmostEqual, 3);
            gradations.Add(FuzzyCompareGradation.BetweenAlmostEqualAndLittleBitGreater, 4);
            gradations.Add(FuzzyCompareGradation.LittleBitGreater, 5);
            gradations.Add(FuzzyCompareGradation.BetweenLittleBitGreaterAndGreater, 6);
            gradations.Add(FuzzyCompareGradation.Greater, 7);
            gradations.Add(FuzzyCompareGradation.BetweenGreaterAndMuchGreater, 8);
            gradations.Add(FuzzyCompareGradation.MuchGreater, 9);
        }

        protected override void RebuildWeights()
        {
            throw new NotImplementedException();
        }
    }
}