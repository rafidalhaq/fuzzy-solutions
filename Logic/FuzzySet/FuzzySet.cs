using System;
using System.Collections.Generic;
using System.Linq;

namespace IGS.Fuzzy.Core
{
    public class FuzzySet<T> : IEquatable<FuzzySet<T>>
    {
        private readonly List<T> universalItems = new List<T>();
        private IFitnessFunction<T> fitnessFunction;
        public event EventHandler<UniversalItemsEventArgs<T>> CollectionChanged;

        public double GetWeight(T item)
        {
            if(universalItems.Contains(item) == false)
                throw new IndexOutOfRangeException("Универсальное множество не содержит элемента, для которого был запрошен вес");

            return fitnessFunction.Invoke(item);
        }
        
        public IEnumerable<T> UniversalItems { get { return universalItems; } }

        public FuzzySet<T> SetFitnessFunction(IFitnessFunction<T> func)
        {
            fitnessFunction = func;

            func.ParentSet = this;

            return this;
        }

        public FuzzySet<T> SetFitnessFunction(Func<T, double> func)
        {
            return SetFitnessFunction(new FitnessFunction(func));
        }

        public bool Equals(FuzzySet<T> other)
        {
            return ItemsEquals(other) 
                && UniversalItems.All(universalItem => GetWeight(universalItem) == other.GetWeight(universalItem));
        }

        public bool ItemsEquals(FuzzySet<T> other)
        {
            if (universalItems.Count != other.UniversalItems.Count())
                return false;

            if (UniversalItems.Any(universalItem => other.UniversalItems.Contains(universalItem) == false))
                return false;

            return true;
        }

        public FuzzySet<T> Add(T universalItem)
        {
            if (AddItem(universalItem))
                InvokeCollectionChanged();

            return this;
        }

        private void InvokeCollectionChanged()
        {
            if (CollectionChanged != null)
                CollectionChanged(this, new UniversalItemsEventArgs<T>());
        }

        public FuzzySet<T> Add(FuzzySet<T> from)
        {
            var collectionChanged = false;

            foreach (var universalItem in from.universalItems)
                collectionChanged = AddItem(universalItem);

            if(collectionChanged)
                InvokeCollectionChanged();

            return this;
        }

        private bool AddItem(T universalItem)
        {
            if (universalItems.Contains(universalItem) == false)
            {
                universalItems.Add(universalItem);
                return true;
            }

            return false;
        }

        private class FitnessFunction : IFitnessFunction<T>
        {
            private Func<T, double> Function { get; set; }

            public FitnessFunction(Func<T, double> func)
            {
                Function  = func;
            }

            public double Invoke(T item)
            {
                return Function.Invoke(item);
            }

            public FuzzySet<T> ParentSet { set { } }

            public void OnUniversalItemsCollectionChanged(object sender, UniversalItemsEventArgs<T> universalItemsEventArgs)
            {
            }
        }
    }
}
