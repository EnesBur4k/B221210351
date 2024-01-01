using B221210351.Middlewares;

namespace B221210351.Extensions
{
    public static class RequestLocalizationCookiesMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLocalizationCookies(this IApplicationBuilder app)
            => app.UseMiddleware<RequestLocalizationCookiesMiddleware>();
    }
}
