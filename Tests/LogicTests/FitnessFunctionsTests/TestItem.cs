﻿using IGS.Fuzzy.Core;
using IGS.Fuzzy.Core.FuzzyGradation;

namespace FitnessFunctionsTests
{
    public class TestItem : IFuzzyComparable<TestItem>
    {
        public TestItem(int value)
        {
            Value = value;
        }

        private int Value { get; set; }

        #region IFuzzyComparable<TestItem> Members

        public FuzzyCompareGradation FuzzyCompareTo(TestItem item)
        {
            int dist = Value - item.Value;

            if (dist < 0)
                return FuzzyCompareGradation.Less;

            if (dist >= 7)
                return FuzzyCompareGradation.MuchGreater;

            if (dist >= 5 && dist < 7)
                return FuzzyCompareGradation.Greater;

            if (dist >= 3 && dist < 5)
                return FuzzyCompareGradation.LittleBitGreater;

            if (dist >= 1 && dist < 3)
                return FuzzyCompareGradation.AlmostEqual;

            return FuzzyCompareGradation.Equal;
        }

        #endregion
    }
}