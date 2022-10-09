using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.Entities.ValueObjects;
using MatchMe.Opportunities.Domain.ValueObjects;
using OpportunitySkill = MatchMe.Opportunities.Domain.Entities.OpportunitySkill;

namespace MatchMe.Opportunities.Domain.Factories
{
    public sealed class OpportunityFactory : IOpportunityFactory
    {
        public Opportunity Create(string Title, string Reference, string Descritption, string ClientId, string Responsible, string Location, OpportunityStatusObject Status, DateTime BeginDate, DateTime EndDate,
            decimal? MinSalaryYear, decimal? MaxSalaryYear, int? MinExperienceMonth, int? MaxExperienceMonth)
        => new(Title, Reference, Descritption, ClientId, Responsible, Location, Status, BeginDate, EndDate, MinSalaryYear, MaxSalaryYear, MinExperienceMonth, MaxExperienceMonth);

        public Opportunity Create(string Title, string Reference, string Descritption, string ClientId, string Responsible, string Location, OpportunityStatusObject Status, DateTime BeginDate, DateTime EndDate,
            decimal? MinSalaryYear, decimal? MaxSalaryYear, int? MinExperienceMonth, int? MaxExperienceMonth, IEnumerable<OpportunitySkill> Skills)
        {
            var opportunity = Create(Title, Reference, Descritption, ClientId, Responsible, Location, Status, BeginDate, EndDate, MinSalaryYear, MaxSalaryYear, MinExperienceMonth, MaxExperienceMonth);

            opportunity.AddSkills(Skills);

            return opportunity;
        }
    }
}
