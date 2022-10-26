using MatchMe.Candidates.Application.Commands.Candidates.Models;
using MatchMe.Candidates.Application.Dto.Candidates;
using MatchMe.Common.Shared.Constants.Enums;
using MediatR;

namespace MatchMe.Candidates.Application.Commands.Candidates
{
    public record UpdateCandidateCommand(long Id,
        string FirstName,
        string LastName,
        string FiscalNumber,
        string CitizenCardNumber,
        DateTime DateOfBirth,
        CandidateAddressCommandModel Address,
        string Nationality, string MobilePhone,
        string Email, GenderEnum Gender,
        MaritalStatusEnum MaritalStatus,
        IEnumerable<CandidateSkillCommandModel> Skills,
        IEnumerable<CandidateEducationCommandModel> Educations,
        IEnumerable<CandidateExperienceCommandModel> Experiences) : IRequest<bool>;
}
