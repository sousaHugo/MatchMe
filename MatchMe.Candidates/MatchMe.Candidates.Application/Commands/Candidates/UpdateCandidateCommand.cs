using MatchMe.Candidates.Application.Commands.Candidates.Models;
using MatchMe.Candidates.Application.Dto.Candidates;
using MatchMe.Common.Shared.Constants.Enums;
using MediatR;

namespace MatchMe.Candidates.Application.Commands.Candidates
{
    public record UpdateCandidateCommand(CandidateUpdateWithDetailsDto CandidateUpdateDto) : IRequest<bool>;
}
