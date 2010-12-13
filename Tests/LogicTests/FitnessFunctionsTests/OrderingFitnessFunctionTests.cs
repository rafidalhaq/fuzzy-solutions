using IGS.Fuzzy.Comparers;
using IGS.Fuzzy.Core;
using IGS.Fuzzy.FitnessFunctions;
using Xunit;

namespace FitnessFunctionsTests
{
    public class OrderingFitnessFunctionTests
    {
        private readonly OrderingFitnessFunction<TestItem> orderingFitnessFunction =
            new OrderingFitnessFunction<TestItem>(new ElementsComparingBasedComparer<TestItem>());

        [Fact]
        public void TestOneElementCase()
        {
            FuzzySet<TestItem> fuzzySet = FuzzySet<TestItem>.Instance()
                .SetFitnessFunction(orderingFitnessFunction);

            var universalItem = new TestItem(13);

            fuzzySet.Add(universalItem);

            Assert.Equal(0, fuzzySet.GetWeight(universalItem));
        }

        [Fact]
        public void TestNormalCase()
        {
            var item1 = new TestItem(20);
            var item2 = new TestItem(1);
            var item3 = new TestItem(24);
            var item4 = new TestItem(6);
            var item5 = new TestItem(25);

            FuzzySet<TestItem> fuzzySet = FuzzySet<TestItem>.Instance()
                .Add(item1)
                .Add(item2)
                .Add(item3)
                .Add(item4)
                .Add(item5)
                .SetFitnessFunction(orderingFitnessFunction);

            Assert.Equal(0.4375, fuzzySet.GetWeight(item1));
            Assert.Equal(0, fuzzySet.GetWeight(item2));
            Assert.Equal(0.5625, fuzzySet.GetWeight(item3));
            Assert.Equal(0.1875, fuzzySet.GetWeight(item4));
            Assert.Equal(0.625, fuzzySet.GetWeight(item5));
        }
    }
}