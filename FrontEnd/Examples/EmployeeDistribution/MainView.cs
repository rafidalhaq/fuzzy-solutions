using System;
using System.Collections.Generic;
using System.Drawing;
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
            var employee = GridToList(dataGridEmployee);
            var posts = GridToList(dataGridPosts);

            Controls.Remove(dataGridPosts);
            dataGridEmployee.Width += dataGridPosts.Width;

            dataGridEmployee.Columns.Clear();

            var dataGridViewColumnIndex = dataGridEmployee.Columns.Add(string.Empty, string.Empty);
            dataGridEmployee.Columns[dataGridViewColumnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridEmployee.Columns[dataGridViewColumnIndex].ReadOnly = true;
            dataGridEmployee.Columns[dataGridViewColumnIndex].DefaultCellStyle = new DataGridViewCellStyle{Font = new Font(dataGridEmployee.Font, FontStyle.Bold), BackColor = Color.LightGray};

            foreach (var perfomanceGradation in presenter.PerfomanceGradations)
            {
                var columnIndex = dataGridEmployee.Columns.Add(perfomanceGradation.Name, perfomanceGradation.Name);
                dataGridEmployee.Columns[columnIndex].Width = 118;
                dataGridEmployee.Columns[columnIndex].ValueType = typeof (double);
            }

            foreach (var emp in employee)
            {
                foreach (var post in posts)
                {
                    var dataGridViewRowIndex = dataGridEmployee.Rows.Add();

                    dataGridEmployee.Rows[dataGridViewRowIndex].Cells[0].Value = string.Format("{0} в должности \"{1}\"", emp, post);
                }
            }
        }

        private static IEnumerable<string> GridToList(DataGridView grid)
        {
            return grid.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells[0].EditedFormattedValue.ToString())
                .Where(x => string.IsNullOrEmpty(x) == false)
                .ToList();
        }
    }
}
