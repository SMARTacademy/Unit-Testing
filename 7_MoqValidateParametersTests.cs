using Moq;
using NUnit.Framework;
using System.Collections;

namespace UnitTestingDemoApplication.Tests
{
    [TestFixture]
    class MoqValidateParametersTests
    {
        [Test]
        public void ShouldVerifyMethodArgs()
        {
            string param = "I am not out there!";
            var mockIlist = new Mock<IList>();
            mockIlist.Setup(x =>
                x.Contains(It.IsAny<string>())).Returns(false);
            var sut = new DemoServiceWithDependency(mockIlist.Object);

            var result = sut.Contains(param);

            mockIlist.Verify(x =>
                x.Contains(It.Is<string>(s => s.Equals(param))));
        }
    }
}
