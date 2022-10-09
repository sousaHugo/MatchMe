using MatchMe.Candidates.Domain.Entities;
using MatchMe.Candidates.Domain.Repositories;
using MatchMe.Candidates.Infrastructure.EF.Contexts;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Common.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Candidates.Infrastructure.EF.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly DbSet<Candidate> _candidateDbSet;
        private readonly WriteDbContext _writeDbContext;
        public CandidateRepository(WriteDbContext WriteDbContext)
        {
            _candidateDbSet = WriteDbContext.Candidate;
            _writeDbContext = WriteDbContext;
        }
        public Task<Candidate> GetAsync(Identity Id, CancellationToken CancellationToken)
        => _candidateDbSet.Include(a => a.Skills).SingleOrDefaultAsync(a => a.Id == Id, CancellationToken);

        public async Task AddAsync(Candidate Candidate, CancellationToken CancellationToken)
        {
            await _candidateDbSet.AddAsync(Candidate);
            await _writeDbContext.SaveChangesAsync(CancellationToken);
        }
        public async Task UpdateAsync(Candidate Candidate, CancellationToken CancellationToken)
        {
            _candidateDbSet.Update(Candidate);
            await _writeDbContext.SaveChangesAsync(CancellationToken);
        }
        public async Task DeleteAsync(Candidate Candidate, CancellationToken CancellationToken)
        {
            _candidateDbSet.Remove(Candidate);
            await _writeDbContext.SaveChangesAsync(CancellationToken);
        }
    }
}
