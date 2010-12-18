using System;
using System.Linq;
using System.Windows.Forms;
using Presenter;

namespace EmployeeDistribution
{
    public partial class MainView : Form
    {
        private IEmployeeDistributionPresenter presenter;

        public MainView(IEmployeeDistributionPresenter employeeDistributionPresenter)
        {
            presenter = employeeDistributionPresenter;
            InitializeComponent();
        }

        private void ButtonNextClick(object sender, EventArgs e)
        {
            var employee = dataGrid.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells[0].EditedFormattedValue.ToString())
                .ToList();

            dataGrid.Columns.Clear();

            var dataGridViewColumn = new DataGridViewColumn
                                         {
                                             AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                                             ReadOnly = true
                                         };

            dataGrid.Columns.Add(dataGridViewColumn);
            foreach (var perfomanceGradation in presenter.PerfomanceGradations)
                dataGrid.Columns.Add(perfomanceGradation.Name, perfomanceGradation.Name);

            foreach (var emp in employee)
            {
                var dataGridViewRow = new DataGridViewRow();
                dataGrid.Rows.Add(dataGridViewRow);

            }
        }
    }
}
