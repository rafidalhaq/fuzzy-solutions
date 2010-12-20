using System.Collections.Generic;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter
{
    public class FuzzyEmployeeReplacement
    {
        public FuzzyEmployeeReplacement(FuzzySet<PerfomanceGradation> fuzzyReplacement, IList<EmployeeOnPost> replacement)
        {
            FuzzyReplacement = fuzzyReplacement;
            Replacement = replacement;
        }

        public IList<EmployeeOnPost> Replacement { get; private set; }
        public FuzzySet<PerfomanceGradation> FuzzyReplacement { get; private set; }
    }
}