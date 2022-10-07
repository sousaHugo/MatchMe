using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MatchMe.Common.Shared.Extensions
{
    public static class HttpContextAccessorExtension
    {
        public static Guid UserGuid(this IHttpContextAccessor HttpContextAccessor)
        {
            var nameIdentifier = HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier);
            return nameIdentifier != null ? Guid.Parse(nameIdentifier.Value) : Guid.NewGuid();
        }
    }
}
