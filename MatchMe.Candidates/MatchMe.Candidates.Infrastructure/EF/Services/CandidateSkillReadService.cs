using MatchMe.Candidates.Application.Dto;
using MatchMe.Candidates.Application.Services;
using MatchMe.Candidates.Infrastructure.EF.Contexts;
using MatchMe.Candidates.Infrastructure.EF.Models;
using MatchMe.Candidates.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Candidates.Infrastructure.EF.Services
{
    public class CandidateSkillReadService : ICandidateSkillReadService
    {
        private readonly DbSet<CandidateSkillReadModel> _candidateSkill;
        public CandidateSkillReadService(ReadDbContext DbContext) => _candidateSkill = DbContext.CandidateSkill;

        public Task<bool> ExistsByIdAsync(long Id) => _candidateSkill.AnyAsync(a => a.Id == Id);
        public async Task<IEnumerable<CandidateSkillGetDto>> GetByCandidateIdAsync(long CandidateId)
        {
            var skills = await _candidateSkill.AsNoTracking().Where(a => a.CandidateId == CandidateId).ToListAsync();

            return skills.Select(skill => skill.AsCandidateSkillGetDto()).AsEnumerable();
        }

        public async Task<CandidateSkillGetDto> GetByIdAsync(long Id)
        {
            var skill = await _candidateSkill.AsNoTracking().SingleOrDefaultAsync(a => a.Id == Id);

            return skill.AsCandidateSkillGetDto();
        }
    }
}
