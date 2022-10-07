using MatchMe.Candidates.Application.Dto.Candidates;

namespace MatchMe.Candidates.Application.Services
{
    public interface ICandidateReadService
    {
        Task<bool> ExistsByFiscalNumberAsync(string FiscalNumber, long? CandidateId = null);
        Task<bool> ExistsByIdAsync(long Id);
        Task<IEnumerable<CandidateGetDto>> GetAllAsync();
        Task<CandidateGetDto> GetByIdAsync(long Id);

    }
}
