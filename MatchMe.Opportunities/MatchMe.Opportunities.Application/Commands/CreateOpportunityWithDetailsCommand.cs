using MatchMe.Opportunities.Application.Commands.Models;
using MediatR;

namespace MatchMe.Opportunities.Application.Commands
{
    public record CreateOpportunityWithDetailsCommand(
        string Title,
        string Description,
        string ClientId,
        string Responsible,
        string Location,
        DateTime BeginDate,
        DateTime EndDate,
        decimal? MinSalaryYear,
        decimal? MaxSalaryYear,
        int? MinExperienceMonth,
        int? MaxExperienceMonth,
         IEnumerable<OpportunitySkillCommandModel> Skills) : IRequest<long>;
}
