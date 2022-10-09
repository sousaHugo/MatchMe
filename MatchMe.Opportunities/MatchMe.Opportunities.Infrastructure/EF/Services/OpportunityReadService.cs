using MatchMe.Opportunities.Application.Dto;
using MatchMe.Opportunities.Application.Services;
using MatchMe.Opportunities.Infrastructure.EF.Contexts;
using MatchMe.Opportunities.Infrastructure.EF.Models;
using MatchMe.Opportunities.Infrastructure.EF.Models.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Opportunities.Infrastructure.EF.Services
{
    internal class OpportunityReadService : IOpportunityReadService
    {
        private readonly DbSet<OpportunityReadModel> _opportunity;
        public OpportunityReadService(ReadDbContext DbContext) => _opportunity = DbContext.Opportunity;

        public Task<bool> ExistsByTitleAsync(string Title)
            => _opportunity.AnyAsync(a => a.Title == Title);
        public async Task<IEnumerable<OpportunityGetDto>> GetAllAsync()
        {
            var allOpportunities = await _opportunity.AsNoTracking().ToListAsync();

            return allOpportunities.Select(opportunity => opportunity.AsOpportunityGetDto()).AsEnumerable();
        }
        public async Task<OpportunityDto> GetByIdAsync(long Id)
        {
            var opportunity = await _opportunity.AsNoTracking().SingleOrDefaultAsync(a => a.Id == Id);

            return opportunity.AsOpportunityDto();
        }
        public async Task<IEnumerable<OpportunitySkillDto>> GetSkillsByOpportunityIdAsync(long OpportunityId)
        {
            var opportunitySkills = await _opportunity.AsNoTracking()
                .Include(s => s.Skills)
                .SelectMany(s => s.Skills)
                .Where(o => o.OpportunityId == OpportunityId)
                .ToListAsync();

            return opportunitySkills.AsOpportunitySkillDto();
        }
    }
}
