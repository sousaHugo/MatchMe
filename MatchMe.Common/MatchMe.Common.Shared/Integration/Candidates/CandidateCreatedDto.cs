using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Common.Shared.MongoDb;

namespace MatchMe.Common.Shared.Integration.Candidates
{
    public record CandidateCreatedDto(long Id, long CandidateId, string FirstName, string LastName, DateTime DateOfBirth, CandidateCreatedAddressDto Address, GenderEnum Gender,
        MaritalStatusEnum MaritalStatus, string Nationality, string MobilePhone, string Email, string FiscalNumber, string CitizenCardNumber,
        IEnumerable<CandidateCreatedSkillDto> Skills) : IMongoEntity;

    public record CandidateCreatedAddressDto(string Street, string City, string State, string PostCode, string Country);
    public record CandidateCreatedSkillDto(long Id, string Name, int Experience, SkillLevelEnum Level);
}
