namespace MatchMe.Common.Shared.Exceptions
{
    public class ApplicationEntityNotFoundException : MatchMeException
    {
        public ApplicationEntityNotFoundException(string Entity, string Value) : base($"Entity {Entity} with the Id: {Value} was not found.")
        {
        }
    }
}
