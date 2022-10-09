﻿using MatchMe.Candidates.Domain.Entities;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Domain.Factories
{
    public sealed class CandidateFactory : ICandidateFactory
    {
        public Candidate Create(string FirstName, string LastName, DateOfBirthObject DateOfBirth, AddressObject Address, GenderObject Gender, MaritalStatusObject MaritalStatus, string Nationality,
          string MobilePhone, EmailObject Email, FiscalNumberObject FiscalNumber, CitizenCardNumberObject CitizenCardNumber)
        => new(FirstName, LastName, DateOfBirth, Address, Gender, MaritalStatus, Nationality, MobilePhone, Email, FiscalNumber, CitizenCardNumber);

        public Candidate Create(string FirstName, string LastName, DateOfBirthObject DateOfBirth, AddressObject Address, GenderObject Gender, MaritalStatusObject MaritalStatus, string Nationality,
            string MobilePhone, EmailObject Email, FiscalNumberObject FiscalNumber, CitizenCardNumberObject CitizenCardNumber, IEnumerable<CandidateSkill> Skills)
        {
            Candidate candidate = new Candidate(FirstName, LastName, DateOfBirth, Address, Gender, MaritalStatus, Nationality, MobilePhone, Email, FiscalNumber, CitizenCardNumber);
            candidate.AddSkills(Skills ?? new List<CandidateSkill>());
            return candidate;
        }
    }
}