using System;
using System.Runtime.Serialization;

namespace ccl.Framework.Exceptions
{
    public class CommandNotCreatedException : Exception
    {
        public CommandNotCreatedException()
        {
        }

        public CommandNotCreatedException(string message) : base(message)
        {
        }

        public CommandNotCreatedException(string message, Exception exception) : base(message, exception)
        {
        }

        protected CommandNotCreatedException(SerializationInfo si, StreamingContext sc)
            : base(si, sc)
        {
        }
    }
}