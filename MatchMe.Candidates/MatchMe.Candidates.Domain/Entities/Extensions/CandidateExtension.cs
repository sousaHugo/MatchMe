using IdGen;
using MatchMe.Candidates.Domain.Entities.Validators;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;
using MatchMe.Common.Shared.Integration.Candidates;
using System.Net;

namespace MatchMe.Candidates.Domain.Entities.Extensions
{
    public static class CandidateExtension
    {
        private static CandidateValidator _validator = new();
        
        public static void Validate(this Candidate Candidate)
        {
            var validationResult = _validator.Validate(Candidate);

            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(Candidate)} Domain:", validationResult.ToDomainEntityValidationException());
        }

        public static CandidateCreatedDto AsCandidateCreatedDto(this Candidate Candidate)
        {
            return new CandidateCreatedDto(Candidate.Id, Candidate.Id, Candidate.FirstName, Candidate.LastName, Candidate.DateOfBirth,
                new CandidateCreatedAddressDto(Candidate.Address.Street, Candidate.Address.City, Candidate.Address.State, Candidate.Address.PostCode,
                Candidate.Address.Country), Candidate.Gender, Candidate.MaritalStatus, Candidate.Nationality, Candidate.MobilePhone,
                Candidate.Email, Candidate.FiscalNumber, Candidate.CitizenCardNumber,
                 Candidate.Skills.Select(s => new CandidateCreatedSkillDto(s.Id, s.Name, s.Experience, s.Level)));
        }
    }
}
