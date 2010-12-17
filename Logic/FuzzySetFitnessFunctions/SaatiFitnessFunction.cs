using System.Linq;
using BusinessLogic.Matrix;
using IGS.Fuzzy.Comparers;
using IGS.Fuzzy.Core.FuzzyGradation;
using Processors;

namespace IGS.Fuzzy.FitnessFunctions
{
    public class SaatiFitnessFunction<T> : FitnessFunctionWithFitnessListBuilding<T>
    {
        public SaatiFitnessFunction(IFuzzyComparer<T> comparer, IFuzzyGradationValueResolver fuzzyGradationValueResolver)
            : base(comparer, fuzzyGradationValueResolver)
        {
        }

        protected override void RebuildWeights()
        {
            Weights.Clear();

            Matrix matrix = BuildSaatiMatrix();
            var transposed = MatrixProcessor.GetTransposedMatrix(matrix);

            var freeRow = transposed.Lines
                .Select(column => column.LineElements.Sum())
                .Select(columnSum => 1/columnSum).ToList();

            for (int i = 0; i < freeRow.Count; i++)
            {
                freeRow[i] /= freeRow.Sum();

                Weights.Add(ParentFuzzySet.UniversalItems[i], freeRow[i]);
            }
        }

        private Matrix BuildSaatiMatrix()
        {
            var matrix = new Matrix();

            foreach (T universalItem in ParentFuzzySet.UniversalItems)
            {
                T item = universalItem;
                matrix.AddLine(new MatrixLine((from otherItem in ParentFuzzySet.UniversalItems
                                               let fuzzyComparingResult = FuzzyComparer.Compare(item, otherItem)
                                               select
                                                   fuzzyComparingResult != FuzzyCompareGradation.Less
                                                       ? FuzzyGradationValueResolver.Resolve(fuzzyComparingResult)
                                                       : 1/
                                                         FuzzyGradationValueResolver.Resolve(
                                                             FuzzyComparer.Compare(otherItem, item))).ToArray()));
            }

            return matrix;
        }
    }
}