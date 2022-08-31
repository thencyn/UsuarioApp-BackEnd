using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace UsuarioApp.WebApi.Excepciones
{
    public class ExcepcionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExcepcionMiddleware> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public ExcepcionMiddleware(RequestDelegate next, ILogger<ExcepcionMiddleware> logger, IHostEnvironment hostEnvironment)
        {
            this._next = next;
            this._logger = logger;
            this._hostEnvironment = hostEnvironment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this._next(context);
            }
            catch (System.Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                var respuesta = new ApiExcepcion(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString());
                var respuestaSerializada = JsonSerializer.Serialize(respuesta, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                await context.Response.WriteAsync(respuestaSerializada);
            }
        }
    }
}