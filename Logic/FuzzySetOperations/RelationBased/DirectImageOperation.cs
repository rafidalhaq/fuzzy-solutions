using System.Collections.Generic;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Multiple;

namespace IGS.Fuzzy.FuzzySetOperations.RelationBased
{
    public class DirectImageOperation<T>
    {
        private IMultipleFuzzySetOperation<T> intersection;

        public DirectImageOperation(IMultipleFuzzySetOperation<T> intersection)
        {
            this.intersection = intersection;
        }

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
                .SetFitnessFunction(x => intersection.Operate(x, fuzzySet).FitnessFunction.GetMax());

            return result;
        }
    }
}