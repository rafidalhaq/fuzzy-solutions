using System.Linq;
using IGS.Fuzzy.Core;

namespace IGS.Fuzzy.FitnessFunctions
{
    public class ConstantFitnessFunction : IFitnessFunction<double>
    {
        private FuzzySet<double> parentSet;

        public FuzzySet<double> ParentSet
        {
            set { parentSet = value; }
        }

        public double Invoke(double item)
        {
            return item;
        }

        public double GetMax()
        {
            return parentSet.UniversalItems.Max();
        }
    }
}