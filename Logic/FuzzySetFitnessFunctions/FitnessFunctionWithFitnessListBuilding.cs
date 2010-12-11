using System.Collections.Generic;
using IGS.Fuzzy.Comparers;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FitnessFunctions
{
    public abstract class FitnessFunctionWithFitnessListBuilding<T> : IFitnessFunction<T>
    {
        protected readonly IFuzzyComparer<T> FuzzyComparer;
        protected FuzzySet<T> ParentFuzzySet;
        protected bool RebuildingRequired;
        protected readonly IDictionary<T, double> Weights = new Dictionary<T, double>();

        public FuzzySet<T> ParentSet
        {
            set
            {
                ParentFuzzySet = value;

                ParentFuzzySet.CollectionChanged += OnUniversalItemsCollectionChanged;

                RebuildWeights();
            }
        }

        protected abstract void RebuildWeights();

        private void OnUniversalItemsCollectionChanged(object sender, UniversalItemsEventArgs<T> universalItemsEventArgs)
        {
            RebuildingRequired = true;
        }

        protected FitnessFunctionWithFitnessListBuilding(IFuzzyComparer<T> comparer)
        {
            FuzzyComparer = comparer;
        }

        public double Invoke(T item)
        {
            if(RebuildingRequired)
                RebuildWeights();

            return Weights[item];
        }
    }
}