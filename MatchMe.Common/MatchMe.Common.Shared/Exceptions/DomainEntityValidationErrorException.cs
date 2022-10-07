namespace MatchMe.Common.Shared.Exceptions
{
    public class DomainEntityValidationErrorException : MatchMeException
    {
        public DomainEntityValidationErrorException(string Message) : base(Message)
        {
        }
    }
}
