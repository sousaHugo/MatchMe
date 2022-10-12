namespace MatchMe.Common.Shared.MongoDb
{
    public class MongoDbOptions
    {
        public string Host { get; init; }
        public int Port { get; init; }
        public string ConnectionString => $"mongodb://{Host}:{Port}";
    }
}
