using System;
using System.Collections;
using System.Collections.Generic;

namespace IGS.Fuzzy.Core
{
    public class FuzzyRelationUniversalItemsCollection<T> : IUniversalItemsCollection<Tuple<T, T>>
    {
        private readonly FuzzySet<T> firstSet;
        private readonly FuzzySet<T> secondSet;
        private readonly IList<Tuple<T, T>> additionalItems = new List<Tuple<T, T>>();

        public FuzzyRelationUniversalItemsCollection(FuzzySet<T> firstSet, FuzzySet<T> secondSet)
        {
            this.firstSet = firstSet;
            this.secondSet = secondSet;
        }

        public void Add(Tuple<T, T> item)
        {
            additionalItems.Add(item);
        }

        public IEnumerator<Tuple<T, T>> GetEnumerator()
        {
            foreach (var universalItemFirst in firstSet.UniversalItems)
                foreach (var universalItemSecond in secondSet.UniversalItems)
                    yield return new Tuple<T, T>(universalItemFirst, universalItemSecond);

            foreach (var additionalItem in additionalItems)
                yield return additionalItem;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}