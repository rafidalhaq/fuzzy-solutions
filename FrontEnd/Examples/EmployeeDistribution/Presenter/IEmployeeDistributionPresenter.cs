using System.Collections.Generic;

namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter
{
    public interface IEmployeeDistributionPresenter
    {
        IEnumerable<PerfomanceGradation> PerfomanceGradations { get; }
        void CalculateBestReplacements(IList<EmployeeOnPost> employeeOnPostsWithEtalone);
    }
}