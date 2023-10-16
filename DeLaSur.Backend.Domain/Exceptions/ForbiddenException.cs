using System.Runtime.Serialization;

namespace DeLaSur.Backend.Domain.Exceptions
{
    [Serializable]
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message)
            : base(message)
        {
        }

        public ForbiddenException(string message, Exception inner)
            : base(message, inner)
        {
        }
        protected ForbiddenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
