using System;
using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTestingDemoApplication.Tests.Attributes
{
    [TestFixture]
    class NUnitAttributesTests
    {
        private int _sut;

        [SetUp]
        public void InitValuesForEachTest()
        {
            Random rnd = new Random();
            _sut = rnd.Next(10, 20);
        }

        [TearDown]
        public void ReleaseResoursesForEachTest()
        {
            _sut = 0;
        }

        [Test]
        public void ShouldBeGreaterThan5()
        {
            Assert.That(_sut, Is.GreaterThan(5));
        }

        [Test]
        public void ShouldBeLessThan4()
        {
            Assert.That(_sut, Is.LessThanOrEqualTo(20));
        }

        [OneTimeSetUp]
        public void InitValuesOnce()
        {
            Random rnd = new Random();
            _sut = rnd.Next(10, 20);
        }

        [OneTimeTearDown]
        public void ReleaseResoursesOnce()
        {
            _sut = 0;
        }
    }

    [SetUpFixture]
    class SetupFixtureTests
    {
        private int _sut;

        [OneTimeSetUp]
        public void InitValuesForEachTest()
        {
            Random rnd = new Random();
            _sut = rnd.Next(10, 20);
        }

        [OneTimeTearDown]
        public void ReleaseResoursesForEachTest()
        {
            _sut = 0;
        }
    }

    [TestFixture]
    public class DataDrivenTests
    {
        [TestCase(2, 5, 10)]
        [TestCase(-2, 5, 10)]
        public void ShouldBeGreaterThanFifty(int num1, int num2, int num3)
        {
            Assert.That(num1 * num2 * num3, Is.GreaterThan(50));
        }

        [Test]
         //[Ignore("For test purposses")]
        public void ShouldBeLessThanFifty(
            [Values(-2, -5, 10)] int num1,
            [Values(-2, 5, -10)] int num2,
            [Values(-2, 5, 10)] int num3)
        {
            Assert.That(num1 * num2 * num3, Is.Not.GreaterThan(50));
        }

        [TestCaseSource(typeof(DemoTestCaseSource))]
        public void ShouldBeEven(int sut)
        {
            Assert.That(sut % 2, Is.EqualTo(0));
        }
    }

    public class DemoTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                    yield return i;
            }
        }
    }

    [TestFixture]
    public class TimeTests
    {
        [Test]
        //[Repeat(2)]
        [MaxTime(400)]
        public void ShouldCompleteFor400Milliseconds()
        {
            Task.Delay(390).Wait();
        }

        [Test]
        [Repeat(400)]
        public void ShouldRun400Times()
        {
            Assert.That(1, Is.EqualTo(1));
        }
    }
}
