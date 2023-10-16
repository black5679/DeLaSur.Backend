using System.Runtime.Serialization;

namespace DeLaSur.Backend.Domain.Exceptions
{
    [Serializable]
    public class NetworkAuthenticationRequiredException : Exception
    {
        public NetworkAuthenticationRequiredException()
        {
        }

        public NetworkAuthenticationRequiredException(string message)
            : base(message)
        {
        }

        public NetworkAuthenticationRequiredException(string message, Exception inner)
            : base(message, inner)
        {
        }
        protected NetworkAuthenticationRequiredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
