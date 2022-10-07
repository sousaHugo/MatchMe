namespace MatchMe.Common.Shared.Dtos
{
    public class ValidationDto
    {
        public ValidationDto(bool IsValid, BadRequestReponseDto Response)
        {
            this.IsValid = IsValid;
            this.Response = Response;
        }

        public bool IsValid { get; set; }

        public BadRequestReponseDto Response { get; set; }
    }
}
