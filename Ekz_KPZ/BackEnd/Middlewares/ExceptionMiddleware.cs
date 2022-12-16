using System.Text.Json;
using System.Net;


namespace InProduct.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly RequestDelegate _requestDelegate;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _requestDelegate = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                httpContext.Response.Headers.AccessControlAllowOrigin = "*";
                await _requestDelegate(httpContext);
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an exception in the middleware: {ex.Message}");
                HandleException(httpContext, ex);
            }
        }

        public async void HandleException(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode;
          
               
           statusCode = HttpStatusCode.InternalServerError;
                
        
            string message = ex.Message;

            var result = JsonSerializer.Serialize(message);
            httpContext.Response.StatusCode = (int)statusCode;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(result);
        }
    }
}
