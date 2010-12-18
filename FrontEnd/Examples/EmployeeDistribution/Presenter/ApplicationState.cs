namespace Presenter
{
    public abstract class ApplicationState
    {
        protected readonly IMainView MainView;

        protected ApplicationState(IMainView mainView)
        {
            this.MainView = mainView;
        }

        public ApplicationState NextState { get; protected set; }

        public abstract void Process();
    }
}