using System;

namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter
{
    public interface IMainView
    {
        event EventHandler Next;
        void AfterEmployeeAndPostsChoosen();
        void AfterExpertRated();
    }
}