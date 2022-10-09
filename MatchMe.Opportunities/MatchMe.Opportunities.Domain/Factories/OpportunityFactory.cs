using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.Entities.Helpers;
using MatchMe.Opportunities.Domain.Entities.ValueObjects;
using OpportunitySkill = MatchMe.Opportunities.Domain.Entities.OpportunitySkill;

namespace MatchMe.Opportunities.Domain.Factories
{
    public sealed class OpportunityFactory : IOpportunityFactory
    {
        public Opportunity Create(string Title, string Description, string ClientId, string Responsible, string Location, DateTime BeginDate, DateTime EndDate,
            decimal? MinSalaryYear, decimal? MaxSalaryYear, int? MinExperienceMonth, int? MaxExperienceMonth)
        => new(Title, OpportunityHelper.GenerateReference(), Description, ClientId, Responsible, Location, new OpportunityStatusObject(OpportunityStatusEnum.Registered), BeginDate, EndDate, MinSalaryYear, MaxSalaryYear, MinExperienceMonth, MaxExperienceMonth);

        public Opportunity Create(string Title, string Description, string ClientId, string Responsible, string Location, DateTime BeginDate, DateTime EndDate,
            decimal? MinSalaryYear, decimal? MaxSalaryYear, int? MinExperienceMonth, int? MaxExperienceMonth, IEnumerable<OpportunitySkill> Skills)
        {
            var opportunity = Create(Title, Description, ClientId, Responsible, Location, BeginDate, EndDate, MinSalaryYear, MaxSalaryYear, MinExperienceMonth, MaxExperienceMonth);

            opportunity.AddSkills(Skills);

            return opportunity;
        }
    }
}
