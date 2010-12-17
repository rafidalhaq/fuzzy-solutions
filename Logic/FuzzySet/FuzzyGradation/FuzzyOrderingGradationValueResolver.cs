using System;
using System.Collections.Generic;

namespace IGS.Fuzzy.Core.FuzzyGradation
{
    public class FuzzyOrderingGradationValueResolver : IFuzzyGradationValueResolver<FuzzyCompareGradation>
    {
        private readonly IDictionary<FuzzyCompareGradation, double> gradationValues = new Dictionary<FuzzyCompareGradation, double>
                                                                                 {
                                                                                     {FuzzyCompareGradation.Equal, 0},
                                                                                     {FuzzyCompareGradation.AlmostEqual, 0.25},
                                                                                     {FuzzyCompareGradation.LittleBitGreater, 0.5},
                                                                                     {FuzzyCompareGradation.Greater, 0.75},
                                                                                     {FuzzyCompareGradation.MuchGreater, 1},
                                                                                     {FuzzyCompareGradation.Less, -1}
                                                                                 };

        public double Resolve(FuzzyCompareGradation gradation)
        {
            return gradationValues[gradation];
        }
    }
}