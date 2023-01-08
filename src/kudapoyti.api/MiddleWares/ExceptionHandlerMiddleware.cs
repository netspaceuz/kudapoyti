using kudapoyti.Service.Common.Exceptions;
using kudapoyti.Service.Dtos.Common;
using Newtonsoft.Json;

namespace kudapoyti.api.MiddleWares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (StatusCodeException exception)
            {
                await HandleErrorAsync(httpContext, exception);
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(httpContext, exception);
            }
        }

        public async Task HandleErrorAsync(HttpContext httpContext, StatusCodeException exception)
        {
            httpContext.Response.ContentType = "application/json";
            ErrorDto errorDto = new()
            {
                StatusCode = (int)exception.StatusCode,
                Message = exception.Message
            };
            string jsonData = JsonConvert.SerializeObject(errorDto, Formatting.Indented);
            httpContext.Response.StatusCode = (int)exception.StatusCode;
            await httpContext.Response.WriteAsync(jsonData);
        }

        public async Task HandleErrorAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            ErrorDto errorDto = new()
            {
                StatusCode = 500,
                Message = exception.Message
            };
            string jsonData = JsonConvert.SerializeObject(errorDto, Formatting.Indented);
            httpContext.Response.StatusCode = 500;
            await httpContext.Response.WriteAsync(jsonData);
        }
    }
}
