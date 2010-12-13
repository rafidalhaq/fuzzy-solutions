using System;
using System.Collections.Generic;
using System.Linq;

namespace IGS.Fuzzy.Core
{
    public class FuzzySet<T> : IEquatable<FuzzySet<T>>
    {
        private readonly IList<T> universalItems;
        private IFitnessFunction<T> fitnessFunction;

        private FuzzySet(FuzzySet<T> fuzzySet)
        {
            universalItems = fuzzySet.universalItems;
        }

        private FuzzySet()
        {
            universalItems = new List<T>();
        }

        public IList<T> UniversalItems
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
            return new FuzzySet<T>();
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

        public double GetWeight(T item)
        {
            if (UniversalItems.Contains(item) == false)
                throw new IndexOutOfRangeException(
                    "Универсальное множество не содержит элемента, для которого был запрошен вес");

            return fitnessFunction.Invoke(item);
        }

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
            bool collectionChanged = false;

            foreach (T universalItem in from.UniversalItems)
                collectionChanged = AddItem(universalItem);

            if (collectionChanged)
                InvokeCollectionChanged();

            return this;
        }

        private bool AddItem(T universalItem)
        {
            if (UniversalItems.Contains(universalItem) == false)
            {
                UniversalItems.Add(universalItem);
                return true;
            }

            return false;
        }

        public IFitnessFunction<T> GetFitnessFunction()
        {
            return fitnessFunction;
        }

        #region Nested type: FitnessFunction

        private class FitnessFunction : IFitnessFunction<T>
        {
            public FitnessFunction(Func<T, double> func)
            {
                Function = func;
            }

            private Func<T, double> Function { get; set; }

            #region IFitnessFunction<T> Members

            public double Invoke(T item)
            {
                return Function.Invoke(item);
            }

            public FuzzySet<T> ParentSet
            {
                set { }
            }

            #endregion
        }

        #endregion
    }
}