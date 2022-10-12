using IdGen;
using MatchMe.Common.Shared.MongoDb;

namespace MatchMe.Common.Shared.Integration.Opportunities
{
    public record OpportunityBaseDto : IMongoEntity
    {
        public OpportunityBaseDto() { }

        public long Id { get => new IdGenerator(0).CreateId(); }
    }
}
