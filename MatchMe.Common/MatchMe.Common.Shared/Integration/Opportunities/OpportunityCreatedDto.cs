using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Common.Shared.Integration.Opportunities
{
    public record OpportunityCreatedDto(long OpportunityId, 
        string Title,
        string Reference,
        string Description,
        string ClientId,
        string Responsible,
        string Location,
        OpportunityStatusEnum Status,
        DateTime BeginDate,
        DateTime EndDate,
        decimal? MinSalaryYear,
        decimal? MaxSalaryYear,
        int? MinExperienceMonth,
        int? MaxExperienceMonth,
        IEnumerable<OpportunitySkillCreatedDto> Skills) : OpportunityBaseDto;

    public record OpportunitySkillCreatedDto(long Id,
        string Name,
        int? MinExperience,
        int? MaxExperience,
        SkillLevelEnum Level,
        bool Mandatory);
}
