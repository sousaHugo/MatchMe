namespace MatchMe.Common.Shared.Exceptions
{
    public class ApplicationEntityAlreadyExistsException : MatchMeException
    {
        public ApplicationEntityAlreadyExistsException(string Entity, string Key, string Value) : base($"Entity {Entity}: {Key} with the value {Value} already exists.")
        {
        }
    }
}
