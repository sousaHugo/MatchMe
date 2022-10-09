using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.Entities.ValueObjects;
using OpportunitySkill = MatchMe.Opportunities.Domain.Entities.OpportunitySkill;

namespace MatchMe.Opportunities.Domain.Factories
{
    public interface IOpportunityFactory
    {
        Opportunity Create(string Title, string Reference, string Descritption, string ClientId, string Responsible, string Location, OpportunityStatusObject Status, DateTime BeginDate, DateTime EndDate,
            decimal? MinSalaryYear, decimal? MaxSalaryYear, int? MinExperienceMonth, int? MaxExperienceMonth);
        Opportunity Create(string Title, string Reference, string Descritption, string ClientId, string Responsible, string Location, OpportunityStatusObject Status, DateTime BeginDate, DateTime EndDate,
            decimal? MinSalaryYear, decimal? MaxSalaryYear, int? MinExperienceMonth, int? MaxExperienceMonth, IEnumerable<OpportunitySkill> Skills);
    }
}
