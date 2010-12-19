namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter.States
{
    public abstract class ApplicationState
    {
        protected readonly IMainView MainView;
        protected readonly IEmployeeDistributionPresenter Presenter;

        protected ApplicationState(IMainView mainView, IEmployeeDistributionPresenter presenter)
        {
            MainView = mainView;
            Presenter = presenter;
        }

        public ApplicationState NextState { get; protected set; }
        
        public abstract void Process();
    }
}