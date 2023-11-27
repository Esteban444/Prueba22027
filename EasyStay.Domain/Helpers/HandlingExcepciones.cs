using System.Net;

namespace EasyStay.Domain.Helpers
{
    public class HandlingExcepciones : Exception
    {
        public HttpStatusCode Codigo { get; }
        public object Error { get; }

        public HandlingExcepciones(HttpStatusCode status, object error = null)
        {
            Codigo = status;
            Error = error;
        }
    }
}
