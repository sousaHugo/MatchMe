using MatchMe.Common.Shared.Constants.Enums;
using System.Collections.ObjectModel;

namespace MatchMe.Opportunities.Infrastructure.EF.Models
{
    public class OpportunityReadModel
    {
        public OpportunityReadModel()
        {
            Skills = new Collection<OpportunitySkillReadModel>();
        }

        public long Id { get; }
        public string Title { get; }
        public string Reference { get;  }
        public string Description { get;  }
        public string ClientId { get;  }
        public string Responsible { get;  }
        public string Location { get; }
        public OpportunityStatusEnum Status { get; }
        public DateTime BeginDate { get;  }
        public DateTime EndDate { get;  }
        public decimal? MinSalaryYear { get;  }
        public decimal? MaxSalaryYear { get;  }
        public int? MinExperienceMonth { get; }
        public int? MaxExperienceMonth { get; }
        public ICollection<OpportunitySkillReadModel> Skills { get; }
    }
}
