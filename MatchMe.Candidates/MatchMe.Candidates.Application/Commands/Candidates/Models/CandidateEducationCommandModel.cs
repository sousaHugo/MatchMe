namespace MatchMe.Candidates.Application.Commands.Candidates.Models
{
    public record CandidateEducationCommandModel
    {
        public long Id { get; init; }
        public string Title { get; init; }
        public string Organization { get; init; }
        public CandidateAddressCommandModel Address { get; init; }
        public DateTime BeginDate { get; init; }
        public DateTime? EndDate { get; init; }
        public string Description { get; init; }
        public CandidateEducationCommandModel(long Id, string Title, string Organization, CandidateAddressCommandModel Address,
           DateTime BeginDate, DateTime? EndDate, string Description)
        {
            this.Id = Id;
            this.Title = Title;
            this.Organization = Organization;
            this.Address = Address;
            this.BeginDate = BeginDate;
            this.EndDate = EndDate;
            this.Description = Description;
        }
        public CandidateEducationCommandModel(string Title, string Organization, CandidateAddressCommandModel Address,
            DateTime BeginDate, DateTime? EndDate, string Description)
        {
            this.Title = Title;
            this.Organization = Organization;
            this.Address = Address;
            this.BeginDate = BeginDate;
            this.EndDate = EndDate;
            this.Description = Description;
        }
    }
}
