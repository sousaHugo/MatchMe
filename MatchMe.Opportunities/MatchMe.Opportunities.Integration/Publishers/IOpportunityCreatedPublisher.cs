using MatchMe.Opportunities.Integration.Dto;

namespace MatchMe.Opportunities.Integration.Publishers
{
    public interface IOpportunityCreatedPublisher
    {
        Task SendAsync(OpportunityCreatedDto OpportunityCreatedDto, CancellationToken CancellationToken = default);
    }
}
