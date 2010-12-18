namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter.States
{
    public class AfterEmployeeAndPostsChoosenState : ApplicationState
    {
        public AfterEmployeeAndPostsChoosenState(IMainView mainView) : base(mainView)
        {
        }

        public override void Process()
        {
            MainView.AfterExpertRated();
        }
    }
}