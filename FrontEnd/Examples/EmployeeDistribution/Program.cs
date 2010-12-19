using System;
using System.Windows.Forms;
using IGS.Fuzzy.Examples.EmployeeDistribution.Presenter;

namespace IGS.Fuzzy.Examples.EmployeeDistribution
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainView = new MainView();
            var employeeDistributionPresenter = new EmployeeDistributionPresenter(mainView);
            mainView.SetPresenter(employeeDistributionPresenter);

            Application.Run(mainView);
        }
    }
}