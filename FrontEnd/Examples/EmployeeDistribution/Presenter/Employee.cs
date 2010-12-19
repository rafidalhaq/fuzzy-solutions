using System;

namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter
{
    public class Employee
    {
        public string Name { get; private set; }

        public Employee(string name)
        {
            Name = name;

            IsEtalone = false;
        }

        public Employee()
        {
            IsEtalone = true;
        }

        public bool IsEtalone { get; private set; }
    }
}