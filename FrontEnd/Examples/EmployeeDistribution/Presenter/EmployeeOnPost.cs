using System.Collections.Generic;

namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter
{
    public class EmployeeOnPost
    {
        public EmployeeOnPost()
        {
            PerfomanceGradations = new Dictionary<PerfomanceGradation, double>();
        }

        public Employee Employee { get; set; }

        public Post Post { get; set; }

        public bool IsEtalone { get; set; }

        public IDictionary<PerfomanceGradation, double> PerfomanceGradations { get; private set; }
    }
}