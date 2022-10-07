using MatchMe.Common.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace MatchMe.Common.Shared.Extensions
{
    public static class CommandsExtensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection ServiceCollection)
        {
            var assembly = Assembly.GetCallingAssembly();

            
            ServiceCollection.Scan(s => s.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
            .AsImplementedInterfaces().WithScopedLifetime());
            
            return ServiceCollection;
        }
    }
}
