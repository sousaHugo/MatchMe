using MatchMe.Common.Shared.Middleware;
using MatchMe.Common.Shared.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MatchMe.Common.Shared.Extensions
{
    public static class SharedExtensions
    {
        public static IServiceCollection AddShared(this IServiceCollection ServiceCollection)
        {
            ServiceCollection.AddHostedService<AppInitializer>();
            ServiceCollection.AddScoped<ExceptionMiddleware>();
            return ServiceCollection;
        }
        public static IApplicationBuilder UseShared(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }
}
