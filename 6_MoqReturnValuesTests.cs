using Moq;
using NUnit.Framework;
using System.Collections;

namespace UnitTestingDemoApplication.Tests
{
    [TestFixture]
    public class MoqReturnValuesTests
    {
        [Test]
        public void ShouldNotContain()
        {
            var _mockIlist = new Mock<IList>();
            _mockIlist.Setup(x =>
                x.Contains(It.IsAny<string>())).Returns(false);
            var sut = new DemoServiceWithDependency(_mockIlist.Object);

            var tricky = "I am not out there!";

            sut.Add(tricky);
            var result = sut.Contains(tricky);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ShouldReturnDifferentValues()
        {
            var _mockIlist = new Mock<IList>();
            bool contains = false;
            _mockIlist.Setup(x => x.Contains(It.IsAny<string>()))
                .Returns(() => contains)
                .Callback(() => contains = !contains);
            
            var sut = new DemoServiceWithDependency(_mockIlist.Object);
            var result1 = sut.Contains("test value");
            var result2 = sut.Contains("test value");

            Assert.That(result1, Is.Not.EqualTo(result2));

            _mockIlist.Verify();
        }
    }
}
