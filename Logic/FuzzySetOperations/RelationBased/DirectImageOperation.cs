using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FuzzySetOperations.Multiple;
using IGS.MathExtensions.Binary;

namespace IGS.Fuzzy.FuzzySetOperations.RelationBased
{
    public class DirectImageOperation<T>
    {
        private readonly IMultipleFuzzySetOperation<T> intersection;

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

    public class SubdirectImageOperation<T>
    {
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
                .SetFitnessFunction(set => fuzzySet.UniversalItems.Min(x => BinaryExtensions.Truncation(fuzzySet.GetWeight(x), set.GetWeight(x))));

            return result;
        }
    }
}