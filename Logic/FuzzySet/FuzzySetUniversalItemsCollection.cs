using System.Collections;
using System.Collections.Generic;

namespace IGS.Fuzzy.Core
{
    class FuzzySetUniversalItemsCollection<T> : IUniversalItemsCollection<T>
    {
        private readonly IList<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}