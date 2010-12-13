using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Binary
{
    public interface IBinaryFuzzySetOperation<T>
    {
        /// <summary>
        /// Возвращает результат конкретной бинарной операции над двумя нечёткими множествами.
        /// </summary>
        /// <param name="first">Первое множество</param>
        /// <param name="second">Второе множество</param>
        /// <returns>Результирующее множество</returns>
        FuzzySet<T> Operate(FuzzySet<T> first, FuzzySet<T> second);
    }
}