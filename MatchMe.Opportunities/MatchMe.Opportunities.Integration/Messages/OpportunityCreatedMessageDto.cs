using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Common.Shared.Integration;

namespace MatchMe.Opportunities.Integration.Messages
{
    public class OpportunityCreatedMessageDto : BaseMessageDto
    {
        public OpportunityCreatedMessageDto(long Id, string Title, string Reference, string Description, string ClientId, string Responsible, string Location, 
            OpportunityStatusEnum Status, DateTime BeginDate, DateTime EndDate, decimal? MinSalaryYear, decimal? MaxSalaryYear, int? MinExperienceMonth, int? MaxExperienceMonth, 
            IEnumerable<OpportunitySkillCreatedMessageDto> Skills)
        {
            this.Id = Id;
            this.Title = Title;
            this.Reference = Reference;
            this.Description = Description;
            this.ClientId = ClientId;
            this.Responsible = Responsible;
            this.Location = Location;
            this.Status = Status;
            this.BeginDate = BeginDate;
            this.EndDate = EndDate;
            this.MinSalaryYear = MinSalaryYear;
            this.MaxSalaryYear = MaxSalaryYear;
            this.MinExperienceMonth = MinExperienceMonth;
            this.MaxExperienceMonth = MaxExperienceMonth;
            this.Skills = Skills;
        }

        public long Id { get; }
        public string Title { get; }
        public string Reference { get; }
        public string Description { get; }
        public string ClientId { get; }
        public string Responsible { get; }
        public string Location { get; }
        public OpportunityStatusEnum Status { get; }
        public DateTime BeginDate { get; }
        public DateTime EndDate { get; }
        public decimal? MinSalaryYear { get; }
        public decimal? MaxSalaryYear { get; }
        public int? MinExperienceMonth { get; }
        public int? MaxExperienceMonth { get; }
        public IEnumerable<OpportunitySkillCreatedMessageDto> Skills { get; }
    }
}
