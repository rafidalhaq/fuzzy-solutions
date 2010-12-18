using System.Collections.Generic;

namespace Presenter
{
    public class EmployeeDistributionPresenter : IEmployeeDistributionPresenter
    {
        public IEnumerable<PerfomanceGradation> PerfomanceGradations { get; private set; }

        public EmployeeDistributionPresenter()
        {
            PerfomanceGradations = new[]
                                       {
                                           new PerfomanceGradation("отличная"),
                                           new PerfomanceGradation("очень хорошая"),
                                           new PerfomanceGradation("довольно хорошая"),
                                           new PerfomanceGradation("довольно плохая"),
                                           new PerfomanceGradation("очень плохая")
                                       };
        }
    }

    public interface IEmployeeDistributionPresenter
    {
        IEnumerable<PerfomanceGradation> PerfomanceGradations { get; }
    }
}
