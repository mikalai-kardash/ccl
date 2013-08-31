using System;
using System.Runtime.Serialization;

namespace ccl.Framework.Exceptions
{
    public class CommandNotRunException : Exception
    {
        public CommandNotRunException()
        {
        }

        public CommandNotRunException(string message) : base(message)
        {
        }

        public CommandNotRunException(string message, Exception exception) : base(message, exception)
        {
        }

        protected CommandNotRunException(SerializationInfo si, StreamingContext sc) : base(si, sc)
        {
        }
    }
}