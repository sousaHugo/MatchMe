using MatchMe.Opportunities.Application.Dto;

namespace MatchMe.Opportunities.Application.Services
{
    public interface IOpportunityReadService
    {
        Task<bool> ExistsByTitleAsync(string Name);
        Task<IEnumerable<OpportunityGetDto>> GetAllAsync();
        Task<OpportunityDto> GetByIdAsync(long Id);
        Task<IEnumerable<OpportunitySkillDto>> GetSkillsByOpportunityIdAsync(long OpportunityId);
    }
}
