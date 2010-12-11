using System;
using System.Linq;
using IGS.Fuzzy.Core;
using TestStubs;
using Xunit;

namespace FuzzySetTests
{
    public class FuzzySetTests
    {
        [Fact]
        public void FuzySetHasOnlyUniques()
        {
            var fuzzySet = new FuzzySet<int>();
            fuzzySet
                .Add(1)
                .Add(1)
                .Add(2);

            Assert.True(fuzzySet.UniversalItems.Contains(1));
            Assert.True(fuzzySet.UniversalItems.Contains(2));
            Assert.Equal(2, fuzzySet.UniversalItems.Count());
        }

        [Fact]
        public void FuzySetMustGenerateEventWhenUniversalItemsCollectionIsChanging()
        {
            var fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();

            var subscriber = new Subscriber();

            fuzzySet.CollectionChanged += subscriber.Handler;

            fuzzySet.Add(13).Add(14);

            Assert.Equal(2, subscriber.Invokes);
        }

        [Fact]
        public void FuzySetShouldNotGenerateEventWhenUniversalItemsCollectionWasnNotChanged()
        {
            var fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();

            var subscriber = new Subscriber();

            fuzzySet.CollectionChanged += subscriber.Handler;

            fuzzySet.Add(1);

            Assert.Equal(0, subscriber.Invokes);
        }

        [Fact]
        public void FuzySetMustGenerateEventOnceWhenRangeOfUniversalItemsWasAdded()
        {
            var fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();
            var other = FuzzySetStubs
                .CreateSimpleIntFuzzySetWithDifferentUniversals()
                .Add(14)
                .Add(15)
                .Add(16);

            var subscriber = new Subscriber();

            fuzzySet.CollectionChanged += subscriber.Handler;

            fuzzySet.Add(other);

            Assert.Equal(1, subscriber.Invokes);
        }

        [Fact]
        public void TestFitnessFunction()
        {
            var fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();

            Assert.Equal(fuzzySet.GetWeight(1), 0.8);
            Assert.Equal(fuzzySet.GetWeight(2), 0.7);
        }

        [Fact]
        public void FitnessFunctionMustThrowExceptionIfThereNoSuchElementInSet()
        {
            var fuzzySet = new FuzzySet<string>();
            const string universalItem = "exist";

            fuzzySet
                .Add(universalItem)
                .SetFitnessFunction(x =>
                                        {
                                            switch (x)
                                            {
                                                case universalItem:
                                                    return 0.8;
                                                default:
                                                    return -1;
                                            }
                                        });

            Assert.Equal(fuzzySet.GetWeight(universalItem), 0.8);
            Assert.Throws<IndexOutOfRangeException>(() => fuzzySet.GetWeight("wrong"));
        }

        [Fact]
        public void ItemsEqualsTest()
        {
            var fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();
            var other = FuzzySetStubs.CreateSimpleIntFuzzySet();

            other.SetFitnessFunction(x => 0);

            Assert.True(fuzzySet.ItemsEquals(other));
        }

        [Fact]
        public void EqualsTest()
        {
            Func<int, double> function = x =>
                                             {
                                                 switch (x)
                                                 {
                                                     case 1:
                                                         return 0.2;
                                                     case 2:
                                                         return 0.3;
                                                     default:
                                                         return 0.4;
                                                 }
                                             };

            // эквивалентное множество
            var fuzzySet = new FuzzySet<int>();
            fuzzySet
                .Add(1)
                .Add(2)
                .SetFitnessFunction(function);

            // эквивалентное множество 
            var fuzzySetEqual = new FuzzySet<int>();
            fuzzySetEqual
                .Add(1)
                .Add(2)
                .SetFitnessFunction(function);

            // неэквивалентно, т.к. закон соответствия иной
            var notEqual1 = new FuzzySet<int>();
            notEqual1
                .Add(1)
                .Add(2)
                .SetFitnessFunction(x =>
                                        {
                                            switch (x)
                                            {
                                                case 1:
                                                    return 0.5;
                                                case 2:
                                                    return 0.6;
                                                default:
                                                    return 0.9;
                                            }
                                        });

            // неэквивалентно, т.к. универсальное множество отличается количественно
            var notEqual2 = new FuzzySet<int>();
            notEqual2.Add(1)
                .SetFitnessFunction(function);

            // неэквивалентно, т.к. универсальное множество отличается качественно
            var notEqual3 = new FuzzySet<int>();
            notEqual3
                .Add(1)
                .Add(3)
                .SetFitnessFunction(function);

            Assert.Equal(fuzzySet, fuzzySetEqual);
            Assert.NotEqual(fuzzySet, notEqual1);
            Assert.NotEqual(fuzzySet, notEqual2);
            Assert.NotEqual(fuzzySet, notEqual3);
        }
    }

    public class Subscriber
    {
        public void Handler(object sender, UniversalItemsEventArgs<int> e)
        {
            Invokes++;
        }

        public int Invokes { get; private set; }
    }
}
