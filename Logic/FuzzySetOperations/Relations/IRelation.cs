using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.Relations
{
    public interface IRelation<TItems, TResult>
    {
        /// <summary>
        /// Возвращает отношение над двумя нечёткими множествами.
        /// </summary>
        /// <param name="first">Первое множество</param>
        /// <param name="second">Второе множество</param>
        /// <returns>Результирующее отношение</returns>
        FuzzySet<TResult> Operate(FuzzySet<TItems> first, FuzzySet<TItems> second);
    }
}