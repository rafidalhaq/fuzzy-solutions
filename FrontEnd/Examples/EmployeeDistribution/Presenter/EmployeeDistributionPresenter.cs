using System;
using System.Collections.Generic;
using IGS.Fuzzy.Examples.EmployeeDistribution.Presenter.States;

namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter
{
    public class EmployeeDistributionPresenter : IEmployeeDistributionPresenter
    {
        private readonly IMainView mainView;
        private ApplicationState applicationState;

        public EmployeeDistributionPresenter(IMainView mainView)
        {
            this.mainView = mainView;
            PerfomanceGradations = new[]
                                       {
                                           new PerfomanceGradation("производительность отличная"),
                                           new PerfomanceGradation("производительность очень хорошая"),
                                           new PerfomanceGradation("производительность довольно хорошая"),
                                           new PerfomanceGradation("производительность довольно плохая"),
                                           new PerfomanceGradation("производительность очень плохая")
                                       };
            mainView.Next += OnNext;

            applicationState = new StateBegin(mainView);
        }

        #region IEmployeeDistributionPresenter Members

        public IEnumerable<PerfomanceGradation> PerfomanceGradations { get; private set; }

        #endregion

        private void OnNext(object sender, EventArgs e)
        {
            applicationState.Process();

            applicationState = applicationState.NextState;
        }
    }
}