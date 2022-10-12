using IdGen;
using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Opportunities.Domain.Entities.Extensions;
using MatchMe.Opportunities.Domain.Entities.ValueObjects;
using MatchMe.Opportunities.Domain.Events;

namespace MatchMe.Opportunities.Domain.Entities
{
    public partial class Opportunity : AggregateRoot<Identity>
    {
        private string _title;
        private readonly string _reference;
        private string _description;
        private string _clientId;
        private string _responsible;
        private string _location;
        private OpportunityStatusObject _status;
        private DateTime _beginDate;
        private DateTime _endDate;
        private decimal? _minSalaryYear;
        private decimal? _maxSalaryYear;
        private int? _minExperienceMonth;
        private int? _maxExperienceMonth;
        private readonly LinkedList<OpportunitySkill> _skills = new();

        public string Title => _title;
        public string Reference => _reference;
        public string Description => _description;
        public string ClientId => _clientId;
        public string Responsible => _responsible;
        public string Location => _location;
        public OpportunityStatusObject Status => _status;
        public DateTime BeginDate => _beginDate;
        public DateTime EndDate => _endDate;
        public decimal? MinSalaryYear => _minSalaryYear;
        public decimal? MaxSalaryYear => _maxSalaryYear;
        public int? MinExperienceMonth => _minExperienceMonth;
        public int? MaxExperienceMonth => _maxExperienceMonth;
        public LinkedList<OpportunitySkill> Skills => _skills;

        private Opportunity() { }

        public Opportunity(string Title, string Reference, string Description, string ClientId, string Responsible, string Location, OpportunityStatusObject Status, DateTime BeginDate, DateTime EndDate,
            decimal? MinSalaryYear, decimal? MaxSalaryYear, int? MinExperienceMonth, int? MaxExperienceMonth)
        {
            Id = new IdGenerator(0).CreateId();
            _title = Title;
            _reference = Reference;
            _description = Description;
            _clientId = ClientId;
            _responsible = Responsible;
            _location = Location;
            _status = Status;
            _beginDate = BeginDate;
            _endDate = EndDate;
            _minSalaryYear = MinSalaryYear;
            _maxSalaryYear = MaxSalaryYear;
            _minExperienceMonth = MinExperienceMonth;
            _maxExperienceMonth = MaxExperienceMonth;

            this.Validate();
            AddEvent(new OpportunityCreateEvent(this));
        }
    }
}
