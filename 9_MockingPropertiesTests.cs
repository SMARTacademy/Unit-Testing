using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace UnitTestingDemoApplication.Tests
{
    [TestFixture]
    class MockingPropertiesTests
    {
        [Test]
        public void ShouldVerifyGet()
        {
            var mockIEnumerable = new Mock<IList<string>>();
            mockIEnumerable.Setup(x => x.Count).Returns(123);
            var sut = new DemoServiceWithDependency(mockIEnumerable.Object);

            var length = sut.GetLength();
            mockIEnumerable.VerifyGet(x=>x.Count);
            //mockIEnumerable.VerifySet(x=>x.Count = It.IsAny<string>());
        }
    }
}
