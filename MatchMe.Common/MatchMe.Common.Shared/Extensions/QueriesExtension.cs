using MatchMe.Common.Shared.Queries;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MatchMe.Common.Shared.Extensions
{
    public static class QueriesExtension
    {
        public static IServiceCollection AddQueries(this IServiceCollection ServiceCollection)
        {
            var assembly = Assembly.GetCallingAssembly();

            ServiceCollection.Scan(s => s.FromAssemblies(assembly)
             .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
             .AsImplementedInterfaces().WithScopedLifetime());


            return ServiceCollection;
        }
    }
}
