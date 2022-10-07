using MatchMe.Common.Shared.Dtos;
using MatchMe.Common.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text.Json;

namespace MatchMe.Common.Shared.Middleware
{
    internal sealed class ExceptionMiddleware : IMiddleware
    {
        public static string ToUnderscoreCase(string value)
         => string.Concat((value ?? string.Empty).Select((x, i) => i > 0 && char.IsUpper(x) && !char.IsUpper(value[i - 1]) ? $"_{x}" : x.ToString())).ToLower();

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (MatchMeException ex)
            {
                context.Response.StatusCode = 400;
                context.Response.Headers.Add("content-type", "application/json");

                var errorCode = ToUnderscoreCase(ex.GetType().Name.Replace("Exception", string.Empty));
                var json = JsonSerializer.Serialize(new { ErrorCode = errorCode, ex.Message, traceId = Activity.Current?.Id ?? context?.TraceIdentifier });
                await context.Response.WriteAsync(json);
            }
            catch (MatchMeMultipleException ex)
            {
                context.Response.StatusCode = 400;
                context.Response.Headers.Add("content-type", "application/json");
                await context.Response.WriteAsync(JsonSerializer.Serialize(new BadRequestReponseDto(Activity.Current?.Id ?? context?.TraceIdentifier, ExceptionsToDictionary(ex))));
            }
        }

        private static Dictionary<string, IEnumerable<string>> ExceptionsToDictionary(MatchMeMultipleException ex)
        {
            return ex.InnerExceptions.Select(a =>
            {
                var splitedMessage = a.Message.Split(";");

                if (splitedMessage.Length == 2)
                    return new KeyValuePair<string, string>(splitedMessage[0], splitedMessage[1]);

                return new KeyValuePair<string, string>("", a.Message);
            }).GroupBy(a => a.Key).ToDictionary(g => g.Key, g => g.Select(a => a.Value).AsEnumerable());
        }
    }
}
