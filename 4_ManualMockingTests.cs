using System.Diagnostics;
using NUnit.Framework;

namespace UnitTestingDemoApplication.Tests
{
    public interface ILogger
    {
        void Log(string content);
    }

    public class MockLogger : ILogger
    {
        public bool LogWasCalled { get; private set; }

        public void Log(string content)
        {
            LogWasCalled = true;
            Debug.WriteLine(content);
        }
    }

    [TestFixture]
    class ManualMockingTests
    {
        [Test]
        public void ShouldWorkWithCustomMock()
        {
            var mockLogger = new MockLogger();
            mockLogger.Log("test string");
            Assert.That(mockLogger.LogWasCalled);
        }
    }
}
