using MatchMe.Candidates.Application.Dto;
using MatchMe.Candidates.Domain.Entities;

namespace MatchMe.Candidates.Application.Services
{
    public interface ICandidateSkillReadService
    {
        Task<bool> ExistsByIdAsync(long Id);
        Task<IEnumerable<CandidateSkillGetDto>> GetByCandidateIdAsync(long CandidateId);
        Task<CandidateSkillGetDto> GetByIdAsync(long Id);
    }
}
