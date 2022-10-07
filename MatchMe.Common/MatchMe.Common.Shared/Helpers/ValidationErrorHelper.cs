namespace MatchMe.Common.Shared.Helpers
{
    public static class ValidationErrorHelper
    {
        public static Dictionary<string, IEnumerable<string>> ToDictionary(IEnumerable<string> Errors)
        {
            return Errors.Select(a =>
            {
                var splitedMessage = a.Split(";");

                if (splitedMessage.Length == 2)
                    return new KeyValuePair<string, string>(splitedMessage[0], splitedMessage[1]);

                return new KeyValuePair<string, string>("", a);
            }).GroupBy(a => a.Key).ToDictionary(g => g.Key, g => g.Select(a => a.Value).AsEnumerable());
        }
    }
}
