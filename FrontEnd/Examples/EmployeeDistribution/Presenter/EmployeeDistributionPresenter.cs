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
                                           new PerfomanceGradation("производительность отличная"),
                                           new PerfomanceGradation("производительность очень хорошая"),
                                           new PerfomanceGradation("производительность довольно хорошая"),
                                           new PerfomanceGradation("производительность довольно плохая"),
                                           new PerfomanceGradation("производительность очень плохая")
                                       };
        }
    }

    public interface IEmployeeDistributionPresenter
    {
        IEnumerable<PerfomanceGradation> PerfomanceGradations { get; }
    }
}
