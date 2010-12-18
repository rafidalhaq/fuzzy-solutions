using System;
using System.Collections.Generic;

namespace Presenter
{
    public class EmployeeDistributionPresenter : IEmployeeDistributionPresenter
    {
        private readonly IMainView mainView;
        private ApplicationState applicationState;
        public IEnumerable<PerfomanceGradation> PerfomanceGradations { get; private set; }
        
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

        private void OnNext(object sender, EventArgs e)
        {
            applicationState.Process();

            applicationState = applicationState.NextState;
        }
    }

    public class StateBegin : ApplicationState
    {
        public StateBegin(IMainView mainView) : base(mainView)
        {
            NextState = new AfterEmployeeAndPostsChoosenState(mainView);
        }

        public override void Process()
        {
            MainView.AfterEmployeeAndPostsChoosen();
        }
    }

    public class AfterEmployeeAndPostsChoosenState : ApplicationState
    {
        public AfterEmployeeAndPostsChoosenState(IMainView mainView) : base(mainView)
        {
        }

        public override void Process()
        {
            throw new NotImplementedException();
        }
    }
}
