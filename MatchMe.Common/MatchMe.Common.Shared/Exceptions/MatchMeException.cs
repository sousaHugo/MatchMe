namespace MatchMe.Common.Shared.Exceptions
{
    public abstract class MatchMeException : Exception
    {
        protected MatchMeException(string Message) : base(Message) { }
    }
    public abstract class MatchMeMultipleException : AggregateException
    {
        protected MatchMeMultipleException(string Message, IEnumerable<Exception> Exceptions) : base(Message, Exceptions) { }
    }
}

