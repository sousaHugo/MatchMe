namespace MatchMe.Candidates.Application.Commands.Candidates.Models
{
    public record CandidateExperienceCommandWriteModel
    {
        public long Id { get; init; }
        public string Role { get; init; }
        public string Company { get; init; }
        public string City { get; init; }
        public string Country { get; init; }
        public DateTime BeginDate { get; init; }
        public DateTime? EndDate { get; init; }
        public string Description { get; init; }
        public string Responsibilities { get; init; }

        public CandidateExperienceCommandWriteModel(long Id, string Role, string Company, string City, string Country, DateTime BeginDate,
           DateTime? EndDate, string Description, string Responsibilities)
        {
            this.Id = Id;
            this.Role = Role;
            this.Company = Company;
            this.City = City;
            this.Country = Country;
            this.BeginDate = BeginDate;
            this.EndDate = EndDate;
            this.Description = Description;
            this.Responsibilities = Responsibilities;
        }
        public CandidateExperienceCommandWriteModel(string Role, string Company, string City, string Country, DateTime BeginDate,
            DateTime? EndDate, string Description, string Responsibilities)
        {
            this.Role = Role;
            this.Company = Company;
            this.City = City;
            this.Country = Country;
            this.BeginDate = BeginDate;
            this.EndDate = EndDate;
            this.Description = Description;
            this.Responsibilities = Responsibilities;
        }
    }
}
