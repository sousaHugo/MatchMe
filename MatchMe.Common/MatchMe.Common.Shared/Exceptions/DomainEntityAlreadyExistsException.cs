namespace MatchMe.Common.Shared.Exceptions
{
    public class DomainEntityAlreadyExistsException : MatchMeException
    {
        public DomainEntityAlreadyExistsException(string Entity, string Key, string Value) : base($"Entity {Entity}: {Key} with the value {Value} already exists.")
        {
        }
    }
}
