namespace MatchMe.Opportunities.Application.Services
{
    public interface IOpportunityReadService
    {
        Task<bool> ExistsByTitleAsync(string Name);
    }
}
