using System;
using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FuzzySetOperations.RelationBased
{
    public class PreimageOperationClassC<T> : PreimageOperationBase<T>
    {
        protected override Func<T, double> GetFitnessFunction(IEnumerable<FuzzySet<T>> relation, FuzzySet<FuzzySet<T>> image)
        {
            return x => relation.Max(y => Math.Min(image.GetWeight(y), y.GetWeight(x)));
        }
    }
}