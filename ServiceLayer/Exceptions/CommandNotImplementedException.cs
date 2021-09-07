using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ServiceLayer.Exceptions
{
    [Serializable]
    public class CommandNotImplementedException : Exception
    {
        public CommandNotImplementedException()
        {
        }

        public CommandNotImplementedException(string message)
            : base(string.Format("Command is not implemented: {0}", message))
        {
        }

        public CommandNotImplementedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CommandNotImplementedException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }

    }
}
