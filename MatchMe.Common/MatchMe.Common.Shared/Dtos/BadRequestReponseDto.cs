namespace MatchMe.Common.Shared.Dtos
{
    public class BadRequestReponseDto
    {
        public BadRequestReponseDto(string TraceId, Dictionary<string, IEnumerable<string>> Errors)
        {
            this.TraceId = TraceId;
            this.Errors = Errors;
        }
        public string Type { get { return "https://tools.ietf.org/html/rfc7231#section-6.5.1"; } }
        public string Title { get { return "One or more validation errors occurred."; } }
        public int Status { get { return 400; } }
        public string TraceId { get; }
        public Dictionary<string, IEnumerable<string>> Errors { get; }
    }
}
