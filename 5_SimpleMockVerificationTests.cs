﻿using System;
using System.Collections;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace UnitTestingDemoApplication.Tests
{
    public class DemoServiceWithDependency
    {
        private readonly IList _iList;

        public DemoServiceWithDependency(IList iList)
        {
            _iList = iList;
        }

        public int Add(object content)
        {
            return _iList.Add(content);
        }

        public void AddRange(IList content)
        {
            foreach (var item in content)
            {
                _iList.Add(item);
            }
        }

        public bool Contains(object subString)
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
        private Mock<IList> _mockIlist;

        [SetUp]
        public void Init()
        {
            _mockIlist = new Mock<IList>();
            _mockIlist.Setup(x => x.Add(It.IsAny<object>()));
            _sut = new DemoServiceWithDependency(_mockIlist.Object);
        }

        [Test]
        public void ShouldPassSimpleVerification()
        {
            _sut.Add(DateTime.Now);

            _mockIlist.Verify(x => x.Add(It.IsAny<DateTime>()));
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
