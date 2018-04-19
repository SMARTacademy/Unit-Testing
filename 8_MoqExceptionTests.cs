using Moq;
using NUnit.Framework;
using System;
using System.Collections;

namespace UnitTestingDemoApplication.Tests
{
    [TestFixture]
    class MoqExceptionTests
    {
        [Test]
        public void ShouldThrowException()
        {
            var mockIlist = new Mock<IList>();
            mockIlist.Setup(x => x.Add(It.Is<string>(s => s.Length >= 10)))
                .Throws<ArgumentException>();
            var sut = new DemoServiceWithDependency(mockIlist.Object);

            Assert.That(()=> sut.Add("impossible"), Throws.Exception);
        }
    }
}
