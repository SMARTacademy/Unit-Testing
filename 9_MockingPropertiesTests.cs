using Moq;
using NUnit.Framework;
using System.Collections;

namespace UnitTestingDemoApplication.Tests
{
    [TestFixture]
    class MockingPropertiesTests
    {
        [Test]
        public void ShouldVerifyGet()
        {
            var mockIlist = new Mock<IList>();
            mockIlist.Setup(x => x.Count).Returns(123);
            var sut = new DemoServiceWithDependency(mockIlist.Object);

            var length = sut.GetLength();
            Assert.That(length, Is.EqualTo(123));
            mockIlist.VerifyGet(x => x.Count);
        }
    }
}
