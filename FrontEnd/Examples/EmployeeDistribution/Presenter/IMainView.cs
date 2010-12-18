using System;

namespace Presenter
{
    public interface IMainView
    {
        event EventHandler Next;
        void AfterEmployeeAndPostsChoosen();
    }
}