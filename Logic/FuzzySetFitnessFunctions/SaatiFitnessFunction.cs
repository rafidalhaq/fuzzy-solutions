using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Matrix;
using IGS.Fuzzy.Comparers;
using IGS.Fuzzy.Core;
using Processors;

namespace IGS.Fuzzy.FitnessFunctions
{
    public class SaatiFitnessFunction<T> : FitnessFunctionWithFitnessListBuilding<T>
    {
        private readonly IDictionary<FuzzyCompareGradation, double> gradations =
            new Dictionary<FuzzyCompareGradation, double>();

        public SaatiFitnessFunction(IFuzzyComparer<T> comparer) : base(comparer)
        {
            InitializeGradationDecryptor();
        }

        private void InitializeGradationDecryptor()
        {
            gradations.Add(FuzzyCompareGradation.Equal, 1);
            gradations.Add(FuzzyCompareGradation.BetweenEqualAndAlmostEqual, 2);
            gradations.Add(FuzzyCompareGradation.AlmostEqual, 3);
            gradations.Add(FuzzyCompareGradation.BetweenAlmostEqualAndLittleBitGreater, 4);
            gradations.Add(FuzzyCompareGradation.LittleBitGreater, 5);
            gradations.Add(FuzzyCompareGradation.BetweenLittleBitGreaterAndGreater, 6);
            gradations.Add(FuzzyCompareGradation.Greater, 7);
            gradations.Add(FuzzyCompareGradation.BetweenGreaterAndMuchGreater, 8);
            gradations.Add(FuzzyCompareGradation.MuchGreater, 9);
        }

        protected override void RebuildWeights()
        {
            Weights.Clear();

            var matrix = BuildSaatiMatrix();
            var transposed = MatrixProcessor.GetTransposedMatrix(matrix);
            
            var freeRow = transposed.Lines
                .Select(column => column.LineElements.Sum())
                .Select(columnSum => 1/columnSum).ToList();

            for (var i = 0; i < freeRow.Count; i++)
            {
                freeRow[i] /= freeRow.Sum();

                Weights.Add(ParentFuzzySet.UniversalItems[i], freeRow[i]);
            }
        }

        private Matrix BuildSaatiMatrix()
        {
            var matrix = new Matrix();

            foreach (var universalItem in ParentFuzzySet.UniversalItems)
            {
                T item = universalItem;
                matrix.AddLine(new MatrixLine((from otherItem in ParentFuzzySet.UniversalItems
                                               let fuzzyComparingResult = FuzzyComparer.Compare(item, otherItem)
                                               select
                                                   fuzzyComparingResult != FuzzyCompareGradation.Less
                                                       ? gradations[fuzzyComparingResult]
                                                       : 1/gradations[FuzzyComparer.Compare(otherItem, item)]).ToArray()));
            }

            return matrix;
        }
    }
}