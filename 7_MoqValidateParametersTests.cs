using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace UnitTestingDemoApplication.Tests
{
    [TestFixture]
    class MoqValidateParametersTests
    {
        [Test]
        public void ShouldVerifyMethodArgs()
        {
            string param = "I am not out there!";
            var mockIEnumerable = new Mock<IList<string>>();
            mockIEnumerable.Setup(x =>
                x.Contains(It.IsAny<string>())).Returns(() => false);
            var sut = new DemoServiceWithDependency(mockIEnumerable.Object);

            var result = sut.Contains(param);

            mockIEnumerable.Verify(x =>
                x.Contains(It.Is<string>(s => s.Equals(param))));
        }
    }
}
