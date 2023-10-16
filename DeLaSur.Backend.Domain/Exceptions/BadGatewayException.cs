using System.Runtime.Serialization;

namespace DeLaSur.Backend.Domain.Exceptions
{
    [Serializable]
    public class BadGatewayException : Exception
    {
        public BadGatewayException()
        {
        }

        public BadGatewayException(string message)
            : base(message)
        {
        }

        public BadGatewayException(string message, Exception inner)
            : base(message, inner)
        {
        }
        protected BadGatewayException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
