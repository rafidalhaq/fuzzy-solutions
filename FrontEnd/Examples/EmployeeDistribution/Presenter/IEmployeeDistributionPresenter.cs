using System.Collections.Generic;

namespace Presenter
{
    public interface IEmployeeDistributionPresenter
    {
        IEnumerable<PerfomanceGradation> PerfomanceGradations { get; }
    }
}