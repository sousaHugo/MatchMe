using MatchMe.Candidates.Application.Dto.Candidates;
using MediatR;


namespace MatchMe.Candidates.Infrastructure.EF.Queries
{
    public class GetCandidateQuery : IRequest<CandidateGetDto>
    {
        public long Id { get; set; }
    }
}
