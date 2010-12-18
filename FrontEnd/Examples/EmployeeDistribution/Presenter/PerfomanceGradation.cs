namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter
{
    public class PerfomanceGradation
    {
        public PerfomanceGradation(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public double Desirability { get; set; }
    }
}