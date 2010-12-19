using System;
using System.Collections.Generic;
using System.Linq;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.Examples.EmployeeDistribution.Presenter.States;
using IGS.Fuzzy.FitnessFunctions;
using IGS.Fuzzy.FuzzySetOperations.Binary.Intersection;

namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter
{
    public class EmployeeDistributionPresenter : IEmployeeDistributionPresenter
    {
        private readonly IMainView mainView;
        private ApplicationState applicationState;

        public EmployeeDistributionPresenter(IMainView mainView)
        {
            this.mainView = mainView;
            PerfomanceGradations = new[]
                                       {
                                           new PerfomanceGradation("производительность отличная"),
                                           new PerfomanceGradation("производительность очень хорошая"),
                                           new PerfomanceGradation("производительность довольно хорошая"),
                                           new PerfomanceGradation("производительность довольно плохая"),
                                           new PerfomanceGradation("производительность очень плохая")
                                       };
            mainView.Next += OnNext;

            applicationState = new StateBegin(mainView, this);
        }

        #region IEmployeeDistributionPresenter Members

        public IEnumerable<PerfomanceGradation> PerfomanceGradations { get; private set; }

        public void CalculateBestReplacements(IList<EmployeeOnPost> employeeOnPostsWithEtalone)
        {
            var employeeOnPosts = employeeOnPostsWithEtalone.Where(x => x.IsEtalone == false);
            var etalone = employeeOnPostsWithEtalone.Where(x => x.IsEtalone == true).FirstOrDefault();

            IList<IList<EmployeeOnPost>> replacements = new List<IList<EmployeeOnPost>>();

            GetReplacements(new List<EmployeeOnPost>{etalone}, employeeOnPosts, replacements);

            IEnumerable<FuzzySet<PerfomanceGradation>> fuzzyReplacements = GetFuzzyReplacements(replacements);

            IList<FuzzySet<PerfomanceGradation>> bestReplacements = GetBestFuzzyReplacements(fuzzyReplacements);
        }

        private static IList<FuzzySet<PerfomanceGradation>> GetBestFuzzyReplacements(IEnumerable<FuzzySet<PerfomanceGradation>> fuzzyReplacements)
        {
            return fuzzyReplacements
                .Where(x => x.GetFitnessFunction().GetMax() == fuzzyReplacements.Max(y => y.GetFitnessFunction().GetMax()))
                .ToList();
        }

        private IEnumerable<FuzzySet<PerfomanceGradation>> GetFuzzyReplacements(IEnumerable<IList<EmployeeOnPost>> replacements)
        {
            IList<FuzzySet<PerfomanceGradation>> fuzzyReplacements = new List<FuzzySet<PerfomanceGradation>>();

            var intersectionOperation = new SimpleIntersectionOperation<PerfomanceGradation>();

            foreach (var replacement in replacements)
            {
                IList<FuzzySet<PerfomanceGradation>> fuzzyEmployeeOnPost = new List<FuzzySet<PerfomanceGradation>>();

                foreach (var employeeOnPost in replacement)
                {
                    var fuzzySet = FuzzySet<PerfomanceGradation>.Instance();
                    foreach (var perfomanceGradation in PerfomanceGradations)
                    {
                        var fitnessFunction = new SwitchFitnessFunction<PerfomanceGradation>(employeeOnPost.PerfomanceGradations);

                        fuzzySet.Add(perfomanceGradation);
                        fuzzySet.SetFitnessFunction(fitnessFunction);
                    }

                    fuzzyEmployeeOnPost.Add(fuzzySet);
                }

                var fuzzyReplacement = intersectionOperation.Operate(fuzzyEmployeeOnPost);
                fuzzyReplacements.Add(fuzzyReplacement);
            }

            return fuzzyReplacements;
        }

        private static void GetReplacements(IList<EmployeeOnPost> currentReplacement, IEnumerable<EmployeeOnPost> itemsLeft, IList<IList<EmployeeOnPost>> replacements)
        {
            if (itemsLeft.Count() == 0)
                replacements.Add(currentReplacement);

            else
            {
                foreach (var itemLeft in itemsLeft.Where(x => x.Employee.Equals(itemsLeft.First().Employee)))
                {
                    var nextIterationReplacement = new List<EmployeeOnPost>(currentReplacement) {itemLeft};

                    EmployeeOnPost empOnPost = itemLeft;

                    GetReplacements(
                        nextIterationReplacement,
                        itemsLeft
                            .Where(x => x.Employee.Equals(empOnPost.Employee) == false)
                            .Where(x => x.Post.Equals(empOnPost.Post) == false),
                        replacements);
                }
            }
        }

        #endregion

        private void OnNext(object sender, EventArgs e)
        {
            applicationState.Process();

            applicationState = applicationState.NextState;
        }
    }
}