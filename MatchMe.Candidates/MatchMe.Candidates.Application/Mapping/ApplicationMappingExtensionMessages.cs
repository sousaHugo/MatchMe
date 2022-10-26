using MatchMe.Candidates.Domain.Entities;
using MatchMe.Candidates.Integration.Messages;


namespace MatchMe.Candidates.Application.Mapping
{
    public static partial class ApplicationMappingExtension
    {
        public static CandidateCreatedMessageDto AsCandidateCreatedMessageDto(this Candidate Candidate)
        {
            return new CandidateCreatedMessageDto(Candidate.Id, Candidate.FirstName, Candidate.LastName, Candidate.DateOfBirth,
                new CandidateCreatedAddressMessageDto(Candidate.Address.Street, Candidate.Address.City, Candidate.Address.State, Candidate.Address.PostCode,
                Candidate.Address.Country), Candidate.Gender, Candidate.MaritalStatus, Candidate.Nationality, Candidate.MobilePhone,
                Candidate.Email, Candidate.FiscalNumber, Candidate.CitizenCardNumber,
                 Candidate.Skills.Select(s => new CandidateCreatedSkillMessageDto(s.Id, s.Name, s.Experience, s.Level)));
        }
    }
}
