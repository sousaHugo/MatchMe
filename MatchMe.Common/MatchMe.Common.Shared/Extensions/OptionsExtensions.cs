using Microsoft.Extensions.Configuration;

namespace MatchMe.Common.Shared.Extensions
{
    public static class OptionsExtensions
    {
        public static TOptions GetOptions<TOptions>(this IConfiguration Configuration, string SectionName) where TOptions : new()
        {
            var options = new TOptions();
            Configuration.GetSection(SectionName).Bind(options);

            return options;
        }
    }
}
