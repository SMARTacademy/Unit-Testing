using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace UnitTestingDemoApplication.Tests
{
    [TestFixture]
    public class MoqReturnValuesTests
    {
        [Test]
        public void ShouldNotContain()
        {
            var mockIEnumerable = new Mock<IList<string>>();
            mockIEnumerable.Setup(x =>
                x.Contains(It.IsAny<string>())).Returns(() => false);
            var sut = new DemoServiceWithDependency(mockIEnumerable.Object);

            var result = sut.Contains("I am not out there!");
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ShouldReturnDifferentValues()
        {
            var mockIEnumerable = new Mock<IList<string>>();
            bool contains = false;
            mockIEnumerable.Setup(x =>
                    x.Contains(It.IsAny<string>()))
                .Returns(() => contains)
                .Callback(() => contains = !contains);
            
            var sut = new DemoServiceWithDependency(mockIEnumerable.Object);

            sut.Contains("test value");
            mockIEnumerable.Verify();
        }
    }
}
