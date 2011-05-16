using System;
using System.Collections.Generic;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.RelationBased
{
    public abstract class ImageOperationBase<T>
    {
        protected abstract Func<FuzzySet<T>, double> GetFitnessFunction(FuzzySet<T> fuzzySet);

        /// <summary>
        /// Нахождение образа
        /// </summary>
        /// <param name="fuzzySet">Нечеткое множество, для которого ищется образ</param>
        /// <param name="relation">Нечеткое отношение</param>
        /// <returns>Образ</returns>
        public FuzzySet<FuzzySet<T>> Operate(FuzzySet<T> fuzzySet, IEnumerable<FuzzySet<T>> relation)
        {
            var result = FuzzySet<FuzzySet<T>>
                .Instance()
                .Add(relation)
                .SetFitnessFunction(GetFitnessFunction(fuzzySet));

            return result;
        }
    }
}