using System;
using System.Collections.Generic;

namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter
{
    public interface IMainView
    {
        event EventHandler Next;
        void AfterEmployeeAndPostsChoosen();
        IList<EmployeeOnPost> AfterExpertRated();
        void ShowResult(IEnumerable<IList<EmployeeOnPost>> result);
    }
}