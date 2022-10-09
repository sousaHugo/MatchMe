namespace MatchMe.Opportunities.Application.Dto
{
    public class OpportunitySkillBaseDto
    {
        public string Name { get; set; }
        public int? MinExperience { get; set; }
        public int? MaxExperience { get; set; }
        public bool Mandatory { get; set; }

    }
}
