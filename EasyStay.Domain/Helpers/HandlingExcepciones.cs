using System.Net;

namespace EasyStay.Domain.Helpers
{
    public class HandlingExcepciones : Exception
    {
        public HttpStatusCode Code { get; }
        public object Error { get; }

        public HandlingExcepciones(HttpStatusCode status, object error = null)
        {
            Code = status;
            Error = error;
        }
    }
}
