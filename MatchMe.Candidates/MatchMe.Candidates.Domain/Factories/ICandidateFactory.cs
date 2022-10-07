using MatchMe.Candidates.Domain.Entities;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Domain.Factories
{
    public interface ICandidateFactory
    {
        Candidate Create(TextObject FirstName, TextObject LastName, DateOfBirthObject DateOfBirth, AddressObject Address, GenderObject Gender, MaritalStatusObject MaritalStatus, TextObject Nationality,
          TextObject MobilePhone, EmailObject Email, FiscalNumberObject FiscalNumber, CitizenCardNumberObject CitizenCardNumber);
        Candidate Create(TextObject FirstName, TextObject LastName, DateOfBirthObject DateOfBirth, AddressObject Address, GenderObject Gender, MaritalStatusObject MaritalStatus, TextObject Nationality,
              TextObject MobilePhone, EmailObject Email, FiscalNumberObject FiscalNumber, CitizenCardNumberObject CitizenCardNumber, IEnumerable<CandidateSkill> Skills);
    }
}
