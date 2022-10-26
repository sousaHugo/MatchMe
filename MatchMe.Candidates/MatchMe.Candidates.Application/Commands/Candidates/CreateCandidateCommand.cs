using MatchMe.Candidates.Application.Commands.Candidates.Models;
using MatchMe.Common.Shared.Constants.Enums;
using MediatR;

namespace MatchMe.Candidates.Application.Commands.Candidates
{
    public record CreateCandidateCommand(string FirstName, 
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
        IEnumerable<CandidateExperienceCommandModel> Experiences) : IRequest<long>;

    
}
