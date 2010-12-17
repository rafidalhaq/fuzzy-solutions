﻿using System.Collections.Generic;
using IGS.Fuzzy.Comparers;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.Core.FuzzyGradation;

namespace IGS.Fuzzy.FitnessFunctions
{
    public abstract class FitnessFunctionWithFitnessListBuilding<T> : IFitnessFunction<T>
    {
        protected readonly IFuzzyComparer<T> FuzzyComparer;
        protected readonly IDictionary<T, double> Weights = new Dictionary<T, double>();
        protected FuzzySet<T> ParentFuzzySet;
        protected bool RebuildingRequired;
        protected IFuzzyGradationValueResolver FuzzyGradationValueResolver;

        protected FitnessFunctionWithFitnessListBuilding(IFuzzyComparer<T> comparer, IFuzzyGradationValueResolver fuzzyGradationValueResolver)
        {
            FuzzyComparer = comparer;
            FuzzyGradationValueResolver = fuzzyGradationValueResolver;
        }

        #region IFitnessFunction<T> Members

        public FuzzySet<T> ParentSet
        {
            set
            {
                ParentFuzzySet = value;

                ParentFuzzySet.CollectionChanged += OnUniversalItemsCollectionChanged;

                RebuildWeights();
            }
        }

        public double Invoke(T item)
        {
            if (RebuildingRequired)
                RebuildWeights();

            return Weights[item];
        }

        #endregion

        protected abstract void RebuildWeights();

        private void OnUniversalItemsCollectionChanged(object sender, UniversalItemsEventArgs<T> universalItemsEventArgs)
        {
            RebuildingRequired = true;
        }
    }
}