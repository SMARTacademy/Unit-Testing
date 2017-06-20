using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace UnitTestingDemoApplication.Tests
{
    [TestFixture]
    class MoqExceptionTests
    {
        [Test]
        public void ShouldThrowException()
        {
            var mockIEnumerable = new Mock<IList<string>>();
            mockIEnumerable.Setup(x => x.Insert(It.Is<int>(n=>n == 15), It.IsAny<string>()))
                .Throws<IndexOutOfRangeException>();
            var sut = new DemoServiceWithDependency(mockIEnumerable.Object);

            Assert.That(()=> sut.Insert("impossible", 15), Throws.Exception);
            ;
        }
    }
}
