using Parlem.Service.Middleware;

namespace Parlem.Service.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddelware>();
        }
    }
}
