namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter.States
{
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
}