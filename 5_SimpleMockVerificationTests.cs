using System;
using System.Collections;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace UnitTestingDemoApplication.Tests
{
    [TestFixture]
    public class SimpleMockVerificationTests
    {
        private DemoServiceWithDependency _sut;
        private Mock<IList> _mockIlist;

        [SetUp]
        public void Init()
        {
            _mockIlist = new Mock<IList>();
            _mockIlist.Setup(x => x.Add(It.IsAny<object>())).Verifiable();
            _sut = new DemoServiceWithDependency(_mockIlist.Object);
        }

        [Test]
        public void ShouldPassSimpleVerification()
        {
            _sut.Add(DateTime.Now);

            _mockIlist.Verify();
        }

        [Test]
        public void ShouldAddRange()
        {
            var valuesToInsert = new List<string> {"hello", "world", "3"};
            _sut.AddRange(valuesToInsert);

            _mockIlist.Verify(x => x.Add(It.IsAny<string>()), Times.Exactly(valuesToInsert.Count));
        }
    }
}
