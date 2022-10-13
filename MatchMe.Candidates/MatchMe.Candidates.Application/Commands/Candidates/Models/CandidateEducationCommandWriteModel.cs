namespace MatchMe.Candidates.Application.Commands.Candidates.Models
{
    public record CandidateEducationCommandWriteModel
    {
        public long Id { get; init; }
        public string Title { get; init; }
        public string Organization { get; init; }
        public CandidateAddressCommandWriteModel Address { get; init; }
        public DateTime BeginDate { get; init; }
        public DateTime? EndDate { get; init; }
        public string Description { get; init; }
        public CandidateEducationCommandWriteModel(long Id, string Title, string Organization, CandidateAddressCommandWriteModel Address,
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
        public CandidateEducationCommandWriteModel(string Title, string Organization, CandidateAddressCommandWriteModel Address,
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
