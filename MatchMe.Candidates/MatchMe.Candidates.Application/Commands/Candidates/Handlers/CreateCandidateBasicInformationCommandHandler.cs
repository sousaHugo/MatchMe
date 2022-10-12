using MatchMe.Candidates.Application.Commands.Candidates;
using MatchMe.Candidates.Application.Services;
using MatchMe.Candidates.Domain.Entities;
using MatchMe.Candidates.Domain.Repositories;
using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Common.Shared.Exceptions;

namespace MatchMe.Candidates.Application.Commands.Handlers
{
    public class CreateCandidateBasicInformationCommandHandler : ICommandHandler<CreateCandidateBasicInformationCommand, long>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ICandidateReadService _candidateReadService;

        public CreateCandidateBasicInformationCommandHandler(ICandidateRepository CandidateRepository,  ICandidateReadService CandidateReadService)
        {
            _candidateRepository = CandidateRepository;
            _candidateReadService = CandidateReadService;
        }

        public async Task<long> Handle(CreateCandidateBasicInformationCommand Request, CancellationToken CancellationToken)
        {
            if (Request.CandidateCreateDto is null)
                throw new ApplicationEntityInvalidException(nameof(Candidate));

            if (await _candidateReadService.ExistsByFiscalNumberAsync(Request.CandidateCreateDto.FiscalNumber))
                throw new ApplicationEntityAlreadyExistsException(nameof(Candidate),"Fiscal Number", Request.CandidateCreateDto.FiscalNumber);

            var candidateCreateDto = Request.CandidateCreateDto;    

            var candidate = Candidate.Create(candidateCreateDto.FirstName, candidateCreateDto.LastName, candidateCreateDto.DateOfBirth, 
                new AddressObject(candidateCreateDto.Address.Street, candidateCreateDto.Address.City, candidateCreateDto.Address.State, candidateCreateDto.Address.PostCode, candidateCreateDto.Address.Country),
                candidateCreateDto.Gender, candidateCreateDto.MaritalStatus, candidateCreateDto.Nationality, candidateCreateDto.MobilePhone,
                candidateCreateDto.Email, candidateCreateDto.FiscalNumber, candidateCreateDto.CitizenCardNumber);

            await _candidateRepository.AddAsync(candidate, CancellationToken);

            return candidate.Id;
        }
    }
}
