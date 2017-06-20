using System;
using System.Runtime.Serialization;

namespace UnitTestingDemoApplication.Tests
{
    [Serializable]
    internal class CustomAssertionException : Exception
    {
        public CustomAssertionException()
        {
        }

        public CustomAssertionException(string message) : base(message)
        {
        }

        public CustomAssertionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomAssertionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}