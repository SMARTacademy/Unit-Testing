using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTestingDemoApplication.Tests
{
    [TestFixture]
    class NUnitAssertsTests
    {
        // Doubles
        [Test]
        public void ShouldAddTwoDoubles()
        {
            Assert.That(3.3, Is.EqualTo(1.1 + 2.2));
        }

        [Test]
        public void ShouldAddTwoDoublesWithTolerance()
        {
            Assert.That(3.3, Is.EqualTo(1.1 + 2.2).Within(0.01));
        }

        [Test]
        public void ShouldAddTwoDoublesWithPercentTolerance()
        {
            Assert.That(101, Is.EqualTo(50 + 50).Within(1).Percent);
        }

        [Test]
        public void ShouldBePositive()
        {
            Assert.That(-1 * -1, Is.Positive);
        }

        [Test]
        public void ShouldNotBeNegatibe()
        {
            Assert.That(1 + 1, Is.Not.Negative);
        }

        [Test]
        public void ShouldBeNan()
        {
            Assert.That(0 / 0.0, Is.NaN);
        }

        // DateTime
        [Test]
        public void ShouldNotBeEqualDateTimes()
        {
            var now = DateTime.Now;
            var oneYearAgo = now.AddYears(-1);
            Assert.That(now, Is.Not.EqualTo(oneYearAgo));
        }

        [Test]
        public void ShouldBeEqualWithToleranceDateTimes()
        {
            var now = DateTime.Now;
            var oneMillisecondAgo = now.AddMilliseconds(-1);
            Assert.That(now, Is.EqualTo(oneMillisecondAgo).Within(TimeSpan.FromMilliseconds(1)));
        }

        [Test]
        public void ShouldBeEqualWithToleranceDateTimesWithFancySyntax()
        {
            var now = DateTime.Now;
            var oneMillisecondAgo = now.AddMilliseconds(-1);
            Assert.That(now, Is.EqualTo(oneMillisecondAgo).Within(1).Milliseconds);
        }

        // Ranges
        [Test]
        public void ShouldBeGreaterThan()
        {
            Random sut = new Random();

            var randomNumber = sut.Next(5, 10);

            Assert.That(randomNumber, Is.GreaterThan(4));
        }

        [Test]
        public void ShouldBeInRange()
        {
            Random sut = new Random();

            var randomNumber = sut.Next(5, 10);

            Assert.That(randomNumber, Is.InRange(4, 11));
        }

        // Nulls and empty values
        [Test]
        public void ShouldNotBeEmpty()
        {
            var sut = string.Empty;

            var result = string.Concat(sut, "hello world!");
            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void ShouldBeNull()
        {
            var sut = new int?();

            Assert.That(sut, Is.Null);
        }

        // Collections
        [Test]
        public void ShouldNotAllBeEmpty()
        {
            var sut = new List<string> { "hello", "world", "3" };

            sut.Add("new item");

            Assert.That(sut, Is.All.Not.Empty);
        }

        [Test]
        public void ShouldContainSpecificElement()
        {
            var sut = new List<string> { "hello", "world", "3" };

            sut.Add("new item");

            Assert.That(sut, Has.Some.Contains("ell"));
        }

        [Test]
        public void ShouldContainTwoSpecificElements()
        {
            var sut = new List<string> { "hello", "world", "3" };

            sut.Add("new item");

            Assert.That(sut, Has.Exactly(2).Contains('o'));
        }

        [Test]
        public void ShouldContainUniqueValues()
        {
            var sut = new List<string> { "hello", "world", "3" };

            sut.Add("new item");
            sut.Add("3");

            Assert.That(sut, Is.Unique);
        }

        [Test]
        public void ShouldNotContainValue()
        {
            var sut = new List<string> { "hello", "world", "4" };

            sut.Add("new item");
            //sut.Add("3");

            Assert.That(sut, Has.None.EqualTo("4"));
        }

        [Test]
        public void ShouldBeEquivalent()
        {
            var sut = new List<string> { "hello", "world", "3" };
            var otherList = new List<string> { "hello", "new item", "world", "3" };

            sut.Add("new item");
            //sut.Add("3");

            Assert.That(sut, Is.EquivalentTo(otherList));
        }

        [Test]
        public void ShouldBeOrdered()
        {
            var sut = new List<string> { "hello", "world", "3", "abc" };

            sut.Sort();

            Assert.That(sut, Is.Ordered);
        }

        // Reference equality
        [Test]
        public void ShouldNotBeSame()
        {
            var sut1 = new int[10];
            var sut2 = new int[10];

            sut1 = sut2;

            Assert.That(sut1, Is.Not.SameAs(sut2));
        }

        // Types
        [Test]
        public void ShouldBeIntArray()
        {
            var sut = new int[10];

            Assert.That(sut, Is.TypeOf<int[]>());
            //Assert.That(sut, Is.TypeOf<IEnumerable>());
        }

        [Test]
        public void ShouldBeIEnumerable()
        {
            var sut = new int[10];

            Assert.That(sut, Is.InstanceOf<IEnumerable>());
        }

        [Test]
        public void ShouldHaveProperty()
        {
            var sut = new int[10];

            Assert.That(sut, Has.Property("Length"));
        }

        // Exceptions
        [Test]
        public void ShouldThrowException()
        {
            var sut = Task.Run(() => throw new Exception());

            Assert.That(sut.Wait, Throws.Exception);
        }

        [Test]
        public void ShouldThrowAggregateException()
        {
            var sut = Task.Run(() => throw new ArgumentException());

            Assert.That(sut.Wait, Throws.TypeOf<ArgumentException>());
            //Assert.That(sut.Wait, Throws.TypeOf<AggregateException>());
        }

        [Test]
        public void ShouldThrowExceptionWithParams()
        {
            var sut = new Action(() => throw new ArgumentException("Wrong argument passed"));

            Assert.That(sut.Invoke, Throws.TypeOf<ArgumentException>().With.Matches<ArgumentException>(e => e.Message == "Wrong argument passed!"));
        }
    }
}
