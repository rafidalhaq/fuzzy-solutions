﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public IList<EmployeeOnPost> AfterExpertRated()
        {
            IList<EmployeeOnPost> employeeOnPosts = new List<EmployeeOnPost>();

            foreach (DataGridViewRow row in dataGridEmployee.Rows)
            {
                var employeeOnPost = row.Tag as EmployeeOnPost;

                if (employeeOnPost != null)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.OwningColumn.Tag is PerfomanceGradation)
                            if (cell.FormattedValue != null)
                                employeeOnPost.PerfomanceGradations.Add((PerfomanceGradation) cell.OwningColumn.Tag,
                                                                        double.Parse(cell.FormattedValue.ToString()));
                    }

                    employeeOnPosts.Add(employeeOnPost);
                }
            }

            return employeeOnPosts;
        }

        public void ShowResult(IEnumerable<IList<EmployeeOnPost>> result)
        {
            var resultText = new StringBuilder();

            foreach (var replacement in result)
            {
                resultText.AppendLine("вариант:");
                foreach (var employeeOnPost in replacement.Where(x => x.IsEtalone == false))
                {
                    resultText.AppendFormat("{0} на посту \"{1}\"", employeeOnPost.Employee.Name, employeeOnPost.Post.Name);
                    resultText.AppendLine();
                }
                resultText.AppendLine();
            }

            MessageBox.Show(resultText.ToString(), @"Наилучшие распределения");
        }

        #endregion

        private void ButtonNextClick(object sender, EventArgs e)
        {
            Next(this, new EventArgs());
        }

        private void PrepareGreedForExpert(IEnumerable<string> employee, IEnumerable<string> posts)
        {
            PrepareColumnsForExpert();

            PrepareRowsForExpert(employee, posts);
        }

        private void PrepareRowsForExpert(IEnumerable<string> employee, IEnumerable<string> posts)
        {
            foreach (string emp in employee)
            {
                foreach (string post in posts)
                {
                    int dataGridViewRowIndex = dataGridEmployee.Rows.Add();

                    dataGridEmployee.Rows[dataGridViewRowIndex].Cells[0].Value = string.Format("{0} в должности \"{1}\"", emp, post);
                    dataGridEmployee.Rows[dataGridViewRowIndex].Tag = new EmployeeOnPost { Employee = new Employee(emp), Post = new Post(post) };
                }
            }

            int lastRowIndex = dataGridEmployee.Rows.Add();

            dataGridEmployee.Rows[lastRowIndex].Cells[0].Value = "степень востребованности производительности";
            dataGridEmployee.Rows[lastRowIndex].Tag = new EmployeeOnPost{IsEtalone = true};
        }

        private void PrepareColumnsForExpert()
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
                dataGridEmployee.Columns[columnIndex].ValueType = typeof(double);
                dataGridEmployee.Columns[columnIndex].Tag = perfomanceGradation;
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

        public void SetPresenter(EmployeeDistributionPresenter employeeDistributionPresenter)
        {
            presenter = employeeDistributionPresenter;
        }
    }
}