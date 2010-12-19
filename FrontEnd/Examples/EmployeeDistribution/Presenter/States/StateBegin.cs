using System;

namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter.States
{
    public class StateBegin : ApplicationState
    {
        public StateBegin(IMainView mainView, IEmployeeDistributionPresenter presenter) : base(mainView, presenter)
        {
            NextState = new AfterEmployeeAndPostsChoosenState(mainView, presenter);
        }

        public override void Process()
        {
            MainView.AfterEmployeeAndPostsChoosen();
        }
    }
}