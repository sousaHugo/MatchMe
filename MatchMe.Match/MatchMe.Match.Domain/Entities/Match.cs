using IdGen;
using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Match.Domain.Entities.Extensions;
using MatchMe.Match.Domain.Entities.ValueObjects;
using MatchMe.Match.Domain.Events;

namespace MatchMe.Match.Domain.Entities
{
    public class Match : AggregateRoot<Identity>
    {
        private long _candidateId;
        private string _candidateName;
        private long _opportunityId;
        private string _opportunityTitle;
        private bool _automatic;
        private decimal _percentage;
        private MatchStatusObject _status;

        public long CandidateId => _candidateId;
        public string CandidateName => _candidateName;
        public long OpportunityId => _opportunityId;
        public string OpportunityTitle => _opportunityTitle;
        public bool Automatic => _automatic;
        public decimal Percentage => _percentage;
        public MatchStatusObject Status => _status; 

        private Match() { }
        public Match(long CandidateId, string CandidateName, long OpportunityId, string OpportunityTitle, bool Automatic, decimal Percentage, MatchStatusObject Status)
        {
            Id = new IdGenerator(0).CreateId();
            _candidateId = CandidateId;
            _candidateName = CandidateName;
            _opportunityId = OpportunityId;
            _opportunityTitle = OpportunityTitle;
            _automatic = Automatic;
            _percentage = Percentage;
            _status = Status;

            this.Validate();
            AddEvent(new MatchCreatedEvent(this));
        }
        public void Update(long CandidateId, string CandidateName, long OpportunityId, string OpportunityTitle, bool Automatic, decimal Percentage, MatchStatusObject Status)
        {
            _candidateId = CandidateId;
            _candidateName = CandidateName;
            _opportunityId = OpportunityId;
            _opportunityTitle = OpportunityTitle;
            _automatic = Automatic;
            _percentage = Percentage;
            _status = Status;

            this.Validate();
            AddEvent(new MatchUpdatedEvent(this));
        }
    }
}
