using System.Collections.Generic;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Binary;

namespace IGS.Fuzzy.FuzzySetOperations.Multiple
{
    public interface IMultipleFuzzySetOperation<T> : IBinaryFuzzySetOperation<T>
    {
        /// <summary>
        /// Возвращает результат конкретной множественной операции над несколькими нечёткими множествами.
        /// </summary>
        /// <param name="sets">Множества</param>
        /// <returns>Результирующее множество</returns>
        FuzzySet<T> Operate(IEnumerable<FuzzySet<T>> sets);
    }
}