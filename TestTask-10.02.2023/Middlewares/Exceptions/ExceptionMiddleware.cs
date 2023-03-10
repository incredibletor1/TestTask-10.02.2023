using System.Net;


namespace TestTask_10._02._2023.Middlewares.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (UnauthorizedAccessException ex)
            {
                await HandleException(httpContext, ex, HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (NullReferenceException ex)
            {
                await HandleException(httpContext, ex, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                await HandleException(httpContext, ex, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (ArgumentException ex)
            {
                await HandleException(httpContext, ex, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                await HandleException(httpContext, ex, HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (NotImplementedException ex)
            {
                await HandleException(httpContext, ex, HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private Task HandleException(HttpContext context, Exception exception, HttpStatusCode httpStatusCode, string message)
        {
            _logger.LogError($"Error in TestTask API: {exception}");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}