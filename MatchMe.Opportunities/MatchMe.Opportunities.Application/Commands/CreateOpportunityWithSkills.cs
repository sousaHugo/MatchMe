using MediatR;

namespace MatchMe.Opportunities.Application.Commands
{
    public record CreateOpportunityWithSkills(Guid Id, string Title, string Description, IEnumerable<SkillWriteModel> Skills) : IRequest<bool>;
    public record SkillWriteModel(string Name, int Experience, bool Mandatory);
}
