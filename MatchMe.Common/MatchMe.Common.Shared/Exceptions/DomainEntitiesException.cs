namespace MatchMe.Common.Shared.Exceptions
{
    public class DomainEntitiesException : MatchMeMultipleException
    {
        public DomainEntitiesException(string Message, IEnumerable<DomainEntityValidationErrorException> Exceptions) : base(Message, Exceptions)
        {
        }
    }
}
