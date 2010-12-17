using System;
using System.Collections.Generic;
using IGS.Fuzzy.Core.FuzzyGradation;

namespace IGS.Fuzzy.FitnessFunctions
{
    public class SaatiOrderingGradationValueResolver : IFuzzyGradationValueResolver
    {
        private readonly IDictionary<FuzzyCompareGradation, double> gradationValues = new Dictionary<FuzzyCompareGradation, double>
                                                                                 {
                                                                                     {FuzzyCompareGradation.Equal, 1},
                                                                                     {FuzzyCompareGradation.BetweenEqualAndAlmostEqual, 2},
                                                                                     {FuzzyCompareGradation.AlmostEqual, 3},
                                                                                     {FuzzyCompareGradation.BetweenAlmostEqualAndLittleBitGreater, 4},
                                                                                     {FuzzyCompareGradation.LittleBitGreater, 5},
                                                                                     {FuzzyCompareGradation.BetweenLittleBitGreaterAndGreater, 6},
                                                                                     {FuzzyCompareGradation.Greater, 7},
                                                                                     {FuzzyCompareGradation.BetweenGreaterAndMuchGreater, 8},
                                                                                     {FuzzyCompareGradation.MuchGreater, 9},
                                                                                     {FuzzyCompareGradation.Less, -1}
                                                                                 };

        public double Resolve(FuzzyCompareGradation gradation)
        {
            try
            {
                return gradationValues[gradation];

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}