using MassTransit;
using MatchMe.Common.Shared.Integration.Candidates;

namespace MatchMe.Candidates.Integration.Publishers
{
    public class CandidateCreatedPublisher : ICandidateCreatedPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public CandidateCreatedPublisher(IPublishEndpoint PublishEndpoint) => _publishEndpoint = PublishEndpoint;
        public Task SendAsync(CandidateCreatedDto CandidateCreatedDto, CancellationToken CancellationToken = default)
        {
            return _publishEndpoint.Publish(CandidateCreatedDto, CancellationToken);
        }
    }
}
