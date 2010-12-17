using System.Collections.Generic;

namespace IGS.Fuzzy.Core.FuzzyGradation
{
    public class FuzzyOrderingGradationValueResolver : IFuzzyGradationValueResolver
    {
        private readonly IDictionary<FuzzyCompareGradation, double> gradationValues = new Dictionary
            <FuzzyCompareGradation, double>
                                                                                          {
                                                                                              {
                                                                                                  FuzzyCompareGradation.
                                                                                                  Equal, 0
                                                                                                  },
                                                                                              {
                                                                                                  FuzzyCompareGradation.
                                                                                                  BetweenEqualAndAlmostEqual
                                                                                                  , 0
                                                                                                  },
                                                                                              {
                                                                                                  FuzzyCompareGradation.
                                                                                                  AlmostEqual, 0.25
                                                                                                  },
                                                                                              {
                                                                                                  FuzzyCompareGradation.
                                                                                                  BetweenAlmostEqualAndLittleBitGreater
                                                                                                  , 0.25
                                                                                                  },
                                                                                              {
                                                                                                  FuzzyCompareGradation.
                                                                                                  LittleBitGreater, 0.5
                                                                                                  },
                                                                                              {
                                                                                                  FuzzyCompareGradation.
                                                                                                  BetweenLittleBitGreaterAndGreater
                                                                                                  , 0.5
                                                                                                  },
                                                                                              {
                                                                                                  FuzzyCompareGradation.
                                                                                                  Greater, 0.75
                                                                                                  },
                                                                                              {
                                                                                                  FuzzyCompareGradation.
                                                                                                  BetweenGreaterAndMuchGreater
                                                                                                  , 0.75
                                                                                                  },
                                                                                              {
                                                                                                  FuzzyCompareGradation.
                                                                                                  MuchGreater, 1
                                                                                                  },
                                                                                              {
                                                                                                  FuzzyCompareGradation.
                                                                                                  Less, -1
                                                                                                  }
                                                                                          };

        #region IFuzzyGradationValueResolver Members

        public double Resolve(FuzzyCompareGradation gradation)
        {
            return gradationValues[gradation];
        }

        #endregion
    }
}