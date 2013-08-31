using System;
using System.Runtime.Serialization;

namespace ccl.Framework.Exceptions
{
    public class CommandNotFoundException : Exception
    {
        public CommandNotFoundException()
        {
        }

        public CommandNotFoundException(string message) : base(message)
        {
        }

        public CommandNotFoundException(string message, Exception exception) : base(message, exception)
        {
        }

        protected CommandNotFoundException(SerializationInfo si, StreamingContext sc)
            : base(si, sc)
        {
        }
    }
}