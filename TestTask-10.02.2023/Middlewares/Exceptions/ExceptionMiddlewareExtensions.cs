

namespace TestTask_10._02._2023.Middlewares.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
