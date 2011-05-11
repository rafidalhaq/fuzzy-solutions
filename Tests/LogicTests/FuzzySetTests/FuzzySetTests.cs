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
            FuzzySet<int> fuzzySet = FuzzySet<int>.Instance();
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
            FuzzySet<int> fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();

            var subscriber = new Subscriber();

            fuzzySet.CollectionChanged += subscriber.Handler;

            fuzzySet.Add(13).Add(14);

            Assert.Equal(2, subscriber.Invokes);
        }

        [Fact]
        public void FuzySetShouldNotGenerateEventWhenUniversalItemsCollectionWasNotChanged()
        {
            FuzzySet<int> fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();

            var subscriber = new Subscriber();

            fuzzySet.CollectionChanged += subscriber.Handler;

            fuzzySet.Add(1);

            Assert.Equal(0, subscriber.Invokes);
        }

        [Fact]
        public void FuzySetMustGenerateEventOnceWhenRangeOfUniversalItemsWasAdded()
        {
            FuzzySet<int> fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();
            FuzzySet<int> other = FuzzySetStubs
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
            FuzzySet<int> fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();

            Assert.Equal(fuzzySet.GetWeight(1), 0.8);
            Assert.Equal(fuzzySet.GetWeight(2), 0.7);
        }

        [Fact]
        public void FitnessFunctionMustThrowExceptionIfThereNoSuchElementInSet()
        {
            FuzzySet<string> fuzzySet = FuzzySet<string>.Instance();
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
            FuzzySet<int> fuzzySet = FuzzySetStubs.CreateSimpleIntFuzzySet();
            FuzzySet<int> other = FuzzySetStubs.CreateSimpleIntFuzzySet();

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
            FuzzySet<int> fuzzySet = FuzzySet<int>.Instance();
            fuzzySet
                .Add(1)
                .Add(2)
                .SetFitnessFunction(function);

            // эквивалентное множество 
            FuzzySet<int> fuzzySetEqual = FuzzySet<int>.Instance();
            fuzzySetEqual
                .Add(1)
                .Add(2)
                .SetFitnessFunction(function);

            // неэквивалентно, т.к. закон соответствия иной
            FuzzySet<int> notEqual1 = FuzzySet<int>.Instance();
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
            FuzzySet<int> notEqual2 = FuzzySet<int>.Instance();
            notEqual2.Add(1)
                .SetFitnessFunction(function);

            // неэквивалентно, т.к. универсальное множество отличается качественно
            FuzzySet<int> notEqual3 = FuzzySet<int>.Instance();
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
        public int Invokes { get; private set; }

        public void Handler(object sender, UniversalItemsEventArgs<int> e)
        {
            Invokes++;
        }
    }
}