using System.Collections.Generic;

namespace IGS.Fuzzy.Core
{
    internal interface IUniversalItemsCollection<T> : IEnumerable<T>
    {
        void Add(T item);
    }
}