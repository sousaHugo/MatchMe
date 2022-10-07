using MatchMe.Candidates.Application.Dto.Candidates;
using MatchMe.Candidates.Application.Services;
using MatchMe.Candidates.Infrastructure.EF.Contexts;
using MatchMe.Candidates.Infrastructure.EF.Models;
using MatchMe.Candidates.Infrastructure.EF.Models.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Candidates.Infrastructure.EF.Services
{
    public class CandidateReadService : ICandidateReadService
    {
        private readonly DbSet<CandidateReadModel> _candidate;
        public CandidateReadService(ReadDbContext DbContext) => _candidate = DbContext.Candidate;

        public Task<bool> ExistsByFiscalNumberAsync(string FiscalNumber, long? CandidateId = null)
            => _candidate.AnyAsync(a => a.FiscalNumber == FiscalNumber && a.Id != CandidateId);

        public Task<bool> ExistsByIdAsync(long Id)
          => _candidate.AnyAsync(a => a.Id == Id);

        public async Task<IEnumerable<CandidateGetDto>> GetAllAsync()
        {
            var allCandidates = await _candidate.AsNoTracking().ToListAsync();

            return allCandidates.Select(candidate => candidate.AsCandidateGetDto()).AsEnumerable();
        }

        public async Task<CandidateGetDto> GetByIdAsync(long Id)
        {
            var candidate = await _candidate.AsNoTracking().Include(a => a.Skills).SingleOrDefaultAsync(a => a.Id == Id);

            return candidate.AsCandidateGetDto();
        }
    }
}
