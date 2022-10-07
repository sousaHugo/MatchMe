namespace MatchMe.Common.Shared.Exceptions
{
    public class ApplicationEntityInvalidException : MatchMeException
    {
        public ApplicationEntityInvalidException(string Entity) : base($"Entity {Entity} is invalid.")
        {
        }
    }
}
