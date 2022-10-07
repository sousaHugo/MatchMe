using MatchMe.Candidates.Application.Dto.Candidates;
using MediatR;


namespace MatchMe.Candidates.Infrastructure.EF.Queries
{
    public class SearchCandidatesQuery : IRequest<IEnumerable<CandidateGetDto>>
    {
        public string Search_Phrase { get; set; }
    }
}
