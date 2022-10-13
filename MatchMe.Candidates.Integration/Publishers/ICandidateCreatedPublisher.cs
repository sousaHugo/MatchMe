using MatchMe.Common.Shared.Integration.Candidates;

namespace MatchMe.Candidates.Integration.Publishers
{
    public interface ICandidateCreatedPublisher
    {
        Task SendAsync(CandidateCreatedDto CandidateCreatedDto, CancellationToken CancellationToken = default);
    }
}
