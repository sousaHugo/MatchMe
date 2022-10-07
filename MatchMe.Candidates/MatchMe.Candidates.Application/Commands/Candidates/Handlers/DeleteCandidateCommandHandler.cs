using MatchMe.Candidates.Application.Commands.Candidates;
using MatchMe.Candidates.Application.Services;
using MatchMe.Candidates.Domain.Entities;
using MatchMe.Candidates.Domain.Repositories;
using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Exceptions;
using MediatR;

namespace MatchMe.Candidates.Application.Commands.Handlers
{
    public class DeleteCandidateCommandHandler : ICommandHandler<DeleteCandidateCommand, Unit>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ICandidateReadService _candidateReadService;

        public DeleteCandidateCommandHandler(ICandidateRepository CandidateRepository, ICandidateReadService CandidateReadService)
        {
            _candidateRepository = CandidateRepository;
            _candidateReadService = CandidateReadService;
        }
        public async Task<Unit> Handle(DeleteCandidateCommand Request, CancellationToken CancellationToken)
        {
            var candidateEf = await _candidateRepository.GetAsync(Request.Id, CancellationToken);

            if (candidateEf == null)
                throw new ApplicationEntityNotFoundException(nameof(Candidate), Request.Id.ToString());

            await _candidateRepository.DeleteAsync(candidateEf, CancellationToken);

            return new Unit();
        }
    }
}
