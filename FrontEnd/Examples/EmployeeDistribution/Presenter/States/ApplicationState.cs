namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter.States
{
    public abstract class ApplicationState
    {
        protected readonly IMainView MainView;

        protected ApplicationState(IMainView mainView)
        {
            MainView = mainView;
        }

        public ApplicationState NextState { get; protected set; }

        public abstract void Process();
    }
}