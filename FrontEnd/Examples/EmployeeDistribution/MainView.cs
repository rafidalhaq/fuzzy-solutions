using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IGS.Fuzzy.Examples.EmployeeDistribution.Presenter;

namespace IGS.Fuzzy.Examples.EmployeeDistribution
{
    public partial class MainView : Form, IMainView
    {
        private EmployeeDistributionPresenter presenter;

        public MainView()
        {
            InitializeComponent();
        }

        #region IMainView Members

        public event EventHandler Next;

        public void AfterEmployeeAndPostsChoosen()
        {
            IEnumerable<string> employee = GridToList(dataGridEmployee);
            IEnumerable<string> posts = GridToList(dataGridPosts);

            Controls.Remove(dataGridPosts);
            dataGridEmployee.Width += dataGridPosts.Width;

            PrepareGreedForExpert(employee, posts);
        }

        public void AfterExpertRated()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void ButtonNextClick(object sender, EventArgs e)
        {
            Next(this, new EventArgs());
        }

        private void PrepareGreedForExpert(IEnumerable<string> employee, IEnumerable<string> posts)
        {
            dataGridEmployee.Columns.Clear();

            int dataGridViewColumnIndex = dataGridEmployee.Columns.Add(string.Empty, string.Empty);
            dataGridEmployee.Columns[dataGridViewColumnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridEmployee.Columns[dataGridViewColumnIndex].ReadOnly = true;
            dataGridEmployee.Columns[dataGridViewColumnIndex].DefaultCellStyle = new DataGridViewCellStyle
                                                                                     {
                                                                                         Font = new Font(dataGridEmployee.Font, FontStyle.Bold),
                                                                                         BackColor = Color.LightGray
                                                                                     };

            foreach (PerfomanceGradation perfomanceGradation in presenter.PerfomanceGradations)
            {
                int columnIndex = dataGridEmployee.Columns.Add(perfomanceGradation.Name, perfomanceGradation.Name);
                dataGridEmployee.Columns[columnIndex].Width = 118;
                dataGridEmployee.Columns[columnIndex].ValueType = typeof (double);
            }

            foreach (string emp in employee)
            {
                foreach (string post in posts)
                {
                    int dataGridViewRowIndex = dataGridEmployee.Rows.Add();

                    dataGridEmployee.Rows[dataGridViewRowIndex].Cells[0].Value = string.Format("{0} в должности \"{1}\"", emp, post);

                    //dataGridEmployee.Rows[dataGridViewRowIndex].Tag = 
                }
            }

            int lastRowIndex = dataGridEmployee.Rows.Add();

            dataGridEmployee.Rows[lastRowIndex].Cells[0].Value = "степень востребованности производительности";
        }

        private static IEnumerable<string> GridToList(DataGridView grid)
        {
            return grid.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells[0].EditedFormattedValue.ToString())
                .Where(x => string.IsNullOrEmpty(x) == false)
                .ToList();
        }

        public void SetPresenter(EmployeeDistributionPresenter employeeDistributionPresenter)
        {
            presenter = employeeDistributionPresenter;
        }
    }
}