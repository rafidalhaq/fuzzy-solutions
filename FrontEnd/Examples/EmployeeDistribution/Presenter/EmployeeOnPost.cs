using System;

namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter
{
    public class EmployeeOnPost
    {
        public Employee Employee { get; set; }

        public Post Post { get; set; }
    }

    public class Post
    {
        public Post(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}