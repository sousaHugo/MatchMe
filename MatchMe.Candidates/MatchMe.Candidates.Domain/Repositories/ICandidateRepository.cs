using MatchMe.Candidates.Domain.Entities;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Domain.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetAsync(Identity Id, CancellationToken CancellationToken);
        Task AddAsync(Candidate Candidate, CancellationToken CancellationToken);
        Task UpdateAsync(Candidate Candidate, CancellationToken CancellationToken);
        Task DeleteAsync(Candidate Candidate, CancellationToken CancellationToken);
    }
}
