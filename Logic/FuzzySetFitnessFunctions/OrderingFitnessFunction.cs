using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Comparers;
using IGS.Fuzzy.Core.FuzzyGradation;

namespace IGS.Fuzzy.FitnessFunctions
{
    public class OrderingFitnessFunction<T> : FitnessFunctionWithFitnessListBuilding<T>
    {
        private readonly IFuzzyGradationValueResolver<FuzzyCompareGradation> fuzzyGradationValueResolver;
        private readonly OrderingComparer<T> orderer;

        public OrderingFitnessFunction(IFuzzyComparer<T> fuzzyComparer, IFuzzyGradationValueResolver<FuzzyCompareGradation> fuzzyGradationValueResolver)
            : base(fuzzyComparer)
        {
            this.fuzzyGradationValueResolver = fuzzyGradationValueResolver;
            orderer = new OrderingComparer<T>(fuzzyComparer);
        }

        protected override void RebuildWeights()
        {
            Weights.Clear();

            int universalItemsCount = ParentFuzzySet.UniversalItems.Count();

            if (universalItemsCount == 0)
                return;

            IList<T> orderedUniversalItems = ParentFuzzySet.UniversalItems
                .OrderBy(x => x, orderer)
                .ToList();

            Weights.Add(orderedUniversalItems.First(), 0);

            if (universalItemsCount == 1)
                return;

            for (int i = 1; i < universalItemsCount; i++)
                Weights.Add(orderedUniversalItems[i],
                            CalculateWeightFor(orderedUniversalItems[i], orderedUniversalItems[i - 1],
                                               universalItemsCount));

            RebuildingRequired = false;
        }

        private double CalculateWeightFor(T current, T previous, int universalItemsCount)
        {
            FuzzyCompareGradation fuzzyCompareResult = FuzzyComparer.Compare(current, previous);

            if(fuzzyCompareResult == FuzzyCompareGradation.Less)
                throw new FitnessFunctionException("Множество универсальных элементов не было упорядочено корректно");

            double result = fuzzyGradationValueResolver.Resolve(fuzzyCompareResult);

            result /= universalItemsCount - 1;

            return result + Invoke(previous);
        }
    }
}