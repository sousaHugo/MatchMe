using System;

namespace MatchMe.Opportunities.Domain.Entities.Helpers
{
    public static class OpportunityHelper
    {
        private static Random _random = new ();

        public static string GenerateReference()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return $"{DateTime.Now.ToString("yyyyMMddHHmmss")}{new string(Enumerable.Repeat(chars, 10).Select(s => s[_random.Next(s.Length)]).ToArray())}"; 
        }
    }
}
