using MatchMe.Common.Shared.Dtos.Integration.Opportunities;

namespace MatchMe.Opportunities.Integration.Publishers
{
    public interface IOpportunityCreatedPublisher
    {
        Task SendAsync(OpportunityCreatedDto OpportunityCreatedDto, CancellationToken CancellationToken = default);
    }
}
