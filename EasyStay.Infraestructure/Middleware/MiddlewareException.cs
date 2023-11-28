using EasyStay.Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace EasyStay.Infrastructure.Middleware
{
    public class MiddlewareException
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<MiddlewareException> _logger;

        public MiddlewareException(RequestDelegate next, ILogger<MiddlewareException> logger)
        {
            _requestDelegate = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception e)
            {
                await HandlingExcepcionAsync(context, e, _logger);
            }
        }

        public async Task HandlingExcepcionAsync(HttpContext context, Exception e, ILogger<MiddlewareException> logger)
        {
            object errores = null;
            switch (e)
            {
                case HandlingExcepciones me:
                    logger.LogError(e, "Error handling");
                    errores = new { Mensage = me.Error };
                    context.Response.StatusCode = (int)me.Code;
                    break;

                case Exception ex:
                    logger.LogError(e, "Server error");
                    errores = new { Mensage = string.IsNullOrWhiteSpace(ex.Message) ? "Error" : ex.Message };
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;

                default:
                    logger.LogError(e, "Unhandled exception");
                    errores = new { Mensage = "Unhandled exception" };
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            if (errores != null)
            {
                var resultados = JsonConvert.SerializeObject(new { errores });
                await context.Response.WriteAsync(resultados);
            }
        }
    }

}
