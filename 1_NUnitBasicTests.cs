using System;
using System.Diagnostics;
using NUnit.Framework;

namespace UnitTestingDemoApplication.Tests
{
    [TestFixture]
    public class NUnitBasicTests
    {
        [Test]
        public void ShouldPass()
        {
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void ShouldFail()
        {
            Assert.That("Hello", Is.EqualTo("World"));
        }

        [Test]
        public void ShouldPassOrNot()
        {
            Trace.WriteLine("What is going on?");
        }

        [Test]
        public void ShouldProbablyFail()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void ShouldPassWithCustomAssert()
        {
            CustomAssert.IsTrue(1 == 1);
        }

        [Test]
        public void ShouldPassWithTripleASyntax()
        {
            // Arrange
            var sut = new string('-', 20);

            // Act
            var result = sut.Replace('-', '+');

            // Assert
            Assert.IsFalse(result.Contains("-"));
        }
    }

    public static class CustomAssert
    {
        public static void IsTrue(bool valueToCheck)
        {
            if (!valueToCheck)
                throw new CustomAssertionException("\nExpected: true\nBut was: false");
        }
    }
}
