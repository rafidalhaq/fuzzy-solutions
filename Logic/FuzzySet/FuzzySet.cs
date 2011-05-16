using System;
using System.Collections.Generic;
using System.Linq;

namespace IGS.Fuzzy.Core
{
    public class FuzzySet<T> : IEquatable<FuzzySet<T>>
    {
        private IUniversalItemsCollection<T> universalItems;

        private FuzzySet(FuzzySet<T> fuzzySet)
        {
            universalItems = fuzzySet.universalItems;
        }

        private FuzzySet()
        {
        }

        public IEnumerable<T> UniversalItems
        {
            get { return universalItems; }
        }

        #region IEquatable<FuzzySet<T>> Members

        public bool Equals(FuzzySet<T> other)
        {
            return ItemsEquals(other)
                   && UniversalItems.All(universalItem => GetWeight(universalItem) == other.GetWeight(universalItem));
        }

        #endregion

        public event EventHandler<UniversalItemsEventArgs<T>> CollectionChanged;

        /// <summary>
        /// Создать нечёткое множество
        /// </summary>
        /// <returns>Нечёткое множество</returns>
        public static FuzzySet<T> Instance()
        {
            var fuzzySet = new FuzzySet<T>
                               {
                                   universalItems = new FuzzySetUniversalItemsCollection<T>()
                               };

            return fuzzySet;
        }

        /// <summary>
        /// Создать нечёткое множество на основании заданного универсального множества
        /// </summary>
        /// <param name="fuzzySet">Источник универсальных элементов</param>
        /// <returns>Нечёткое множество</returns>
        public static FuzzySet<T> Instance(FuzzySet<T> fuzzySet)
        {
            return new FuzzySet<T>(fuzzySet);
        }

        public static FuzzySet<Tuple<T, T>> InstanceRelation(FuzzySet<T> first, FuzzySet<T> second)
        {
            var fuzzySet = new FuzzySet<Tuple<T, T>>
                               {
                                   universalItems = new FuzzyRelationUniversalItemsCollection<T>(first, second)
                               };

            return fuzzySet;
        }

        public double GetWeight(T item)
        {
            if (UniversalItems.Contains(item) == false)
                throw new IndexOutOfRangeException(
                    "Универсальное множество не содержит элемента, для которого был запрошен вес");

            return FitnessFunction.Invoke(item);
        }

        public FuzzySet<T> SetFitnessFunction(IFitnessFunction<T> func)
        {
            FitnessFunction = func;

            func.ParentSet = this;

            return this;
        }

        public FuzzySet<T> SetFitnessFunction(Func<T, double> func)
        {
            return SetFitnessFunction(new LambdaFitnessFunction(func, this));
        }

        public bool ItemsEquals(FuzzySet<T> other)
        {
            if (UniversalItems.Count() != other.UniversalItems.Count())
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
            return Add(from.UniversalItems);
        }

        private bool AddItem(T universalItem)
        {
            if (UniversalItems.Contains(universalItem) == false)
            {
                universalItems.Add(universalItem);
                return true;
            }

            return false;
        }

        public FuzzySet<T> Add(IEnumerable<T> items)
        {
            bool collectionChanged = false;

            foreach (T universalItem in items)
                collectionChanged = AddItem(universalItem);

            if (collectionChanged)
                InvokeCollectionChanged();

            return this;
        }

        public IFitnessFunction<T> FitnessFunction { get; private set; }

        #region Nested type: FitnessFunction

        private class LambdaFitnessFunction : IFitnessFunction<T>
        {
            public LambdaFitnessFunction(Func<T, double> func, FuzzySet<T> parentSet)
            {
                Function = func;
                ParentSet = parentSet;
            }

            private Func<T, double> Function { get; set; }

            #region IFitnessFunction<T> Members

            public double Invoke(T item)
            {
                return Function.Invoke(item);
            }

            public double GetMax()
            {
                return ParentSet.UniversalItems.Max(x => Invoke(x));
            }

            public FuzzySet<T> ParentSet { private get; set; }

            #endregion
        }

        #endregion
    }
}