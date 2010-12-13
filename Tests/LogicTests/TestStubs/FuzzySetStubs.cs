using IGS.Fuzzy.Core;

namespace TestStubs
{
    public static class FuzzySetStubs
    {
        public static FuzzySet<int> CreateSimpleIntFuzzySet()
        {
            FuzzySet<int> fuzzySet = FuzzySet<int>.Instance();

            return fuzzySet
                .Add(1)
                .Add(2)
                .SetFitnessFunction(x =>
                                        {
                                            switch (x)
                                            {
                                                case 1:
                                                    return 0.8;
                                                case 2:
                                                    return 0.7;
                                                default:
                                                    return -1;
                                            }
                                        });
        }

        public static FuzzySet<int> CreateSimpleIntFuzzySetWithDifferentUniversals()
        {
            FuzzySet<int> fuzzySet = FuzzySet<int>.Instance();

            return fuzzySet
                .Add(1)
                .Add(3)
                .SetFitnessFunction(x =>
                                        {
                                            switch (x)
                                            {
                                                case 1:
                                                    return 1;
                                                case 2:
                                                    return 0.2;
                                                default:
                                                    return -1;
                                            }
                                        });
        }
    }
}