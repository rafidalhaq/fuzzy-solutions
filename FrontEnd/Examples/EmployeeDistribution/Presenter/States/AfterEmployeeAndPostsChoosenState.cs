namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter.States
{
    public class AfterEmployeeAndPostsChoosenState : ApplicationState
    {
        public AfterEmployeeAndPostsChoosenState(IMainView mainView, IEmployeeDistributionPresenter presenter) : base(mainView, presenter)
        {
        }

        public override void Process()
        {
            var employeeOnPosts = MainView.AfterExpertRated();

            Presenter.CalculateBestReplacements(employeeOnPosts);
        }
    }
}