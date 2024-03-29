﻿using System;

namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter
{
    public class Employee : IEquatable<Employee>
    {
        public string Name { get; private set; }

        public Employee(string name)
        {
            Name = name;
        }

        public bool Equals(Employee other)
        {
            return Name.Equals(other.Name);
        }
    }
}