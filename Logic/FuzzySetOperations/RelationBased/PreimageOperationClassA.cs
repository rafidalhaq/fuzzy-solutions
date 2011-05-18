using System;
using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Core;
using IGS.MathExtensions.Binary;

namespace IGS.Fuzzy.FuzzySetOperations.RelationBased
{
    public class PreimageOperationClassA<T> : PreimageOperationBase<T>
    {
        protected override Func<T, double> GetFitnessFunction(IEnumerable<FuzzySet<T>> relation, FuzzySet<FuzzySet<T>> image)
        {
            return x => relation.Min(y => BinaryExtensions.Truncation(y.GetWeight(x), image.GetWeight(y)));
        }
    }
}