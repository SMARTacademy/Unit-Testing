using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace UnitTestingDemoApplication.Tests
{
    public class DemoServiceWithDependency
    {
        private readonly IList<string> _iList;

        public DemoServiceWithDependency(IList<string> iList)
        {
            _iList = iList;
        }

        public void Insert(string content, int position = 0)
        {
            _iList.Insert(position, content);
        }

        public void InsertRange(IEnumerable<string> content)
        {
            foreach (string s in content)
            {
                _iList.Insert(_iList.Count, s);
            }
        }

        public bool Contains(string subString)
        {
            return _iList.Contains(subString);
        }

        public int GetLength()
        {
            return _iList.Count;
        }
    }

    [TestFixture]
    public class SimpleMockVerificationTests
    {
        private DemoServiceWithDependency _sut;
        private Mock<IList<string>> _mockIEnumerable;

        [SetUp]
        public void Init()
        {
            _mockIEnumerable = new Mock<IList<string>>();
            _mockIEnumerable.Setup(x => x.Insert(It.IsAny<int>(), It.IsAny<string>()));
            _sut = new DemoServiceWithDependency(_mockIEnumerable.Object);
        }

        [Test]
        public void ShouldPassSimpleVerification()
        {
            _sut.Insert("hello");

            _mockIEnumerable.Verify();
        }

        [Test]
        public void ShouldAddRange()
        {
            string[] valuesToInsert = {"hello", "world", "3"};
            _sut.InsertRange(valuesToInsert);

            _mockIEnumerable.Verify(x => x.Insert(It.IsAny<int>(), It.IsAny<string>()), Times.Exactly(valuesToInsert.Length));
        }
    }
}
