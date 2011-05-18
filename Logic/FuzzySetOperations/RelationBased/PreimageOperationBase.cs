using System;
using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.RelationBased
{
    public abstract class PreimageOperationBase<T>
    {
        protected abstract Func<T, double> GetFitnessFunction(IEnumerable<FuzzySet<T>> relation, FuzzySet<FuzzySet<T>> image);

        /// <summary>
        /// Нахождение прообраза
        /// </summary>
        /// <param name="image">Образ</param>
        /// <param name="relation">Нечеткое отношение</param>
        /// <returns>Образ</returns>
        public FuzzySet<T> Operate(FuzzySet<FuzzySet<T>> image, IEnumerable<FuzzySet<T>> relation)
        {
            var result = FuzzySet<T>
                .Instance();

            if (relation.Count() != 0)
                result.Add(relation.First()).SetFitnessFunction(GetFitnessFunction(relation, image));

            return result;
        }
    }
}