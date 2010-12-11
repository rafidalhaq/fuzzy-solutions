using System;
using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Comparers;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FitnessFunctions
{
    public class OrderingFitnessFunction<T> : FitnessFunctionWithFitnessListBuilding<T>
    {
        private readonly OrderingComparer<T> orderer;
        private readonly IDictionary<FuzzyCompareGradation, double> gradations = new Dictionary<FuzzyCompareGradation, double>();

        public OrderingFitnessFunction(IFuzzyComparer<T> fuzzyComparer)
            :base(fuzzyComparer)
        {
            orderer = new OrderingComparer<T>(fuzzyComparer);

            InitializeGradationDecryptor();
        }

        private void InitializeGradationDecryptor()
        {
            gradations.Add(FuzzyCompareGradation.Equal, 0);
            gradations.Add(FuzzyCompareGradation.BetweenEqualAndAlmostEqual, 0);
            gradations.Add(FuzzyCompareGradation.AlmostEqual, 0.25);
            gradations.Add(FuzzyCompareGradation.BetweenAlmostEqualAndLittleBitGreater, 0.25);
            gradations.Add(FuzzyCompareGradation.LittleBitGreater, 0.5);
            gradations.Add(FuzzyCompareGradation.BetweenLittleBitGreaterAndGreater, 0.5);
            gradations.Add(FuzzyCompareGradation.Greater, 0.75);
            gradations.Add(FuzzyCompareGradation.BetweenGreaterAndMuchGreater, 0.75);
            gradations.Add(FuzzyCompareGradation.MuchGreater, 1);
        }

        protected override void RebuildWeights()
        {
            Weights.Clear();

            var universalItemsCount = ParentFuzzySet.UniversalItems.Count();

            if (universalItemsCount == 0)
                return;

            IList<T> orderedUniversalItems = ParentFuzzySet.UniversalItems
                .OrderBy(x => x, orderer)
                .ToList();

            Weights.Add(orderedUniversalItems.First(), 0);

            if (universalItemsCount == 1)
                return;

            for (var i = 1; i < universalItemsCount; i++)
                Weights.Add(orderedUniversalItems[i], CalculateWeightFor(orderedUniversalItems[i], orderedUniversalItems[i - 1], universalItemsCount));

            RebuildingRequired = false;
        }

        private double CalculateWeightFor(T current, T previous, int universalItemsCount)
        {
            FuzzyCompareGradation fuzzyCompareResult = FuzzyComparer.Compare(current, previous);

            double result;

            if(gradations.TryGetValue(fuzzyCompareResult, out result) == false)  
                    throw new FitnessFunctionException("Множество универсальных элементов не было упорядочено корректно");

            result /= universalItemsCount - 1;

            return result + Invoke(previous);
        }
    }
}