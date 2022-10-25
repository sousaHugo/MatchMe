using MatchMe.Candidates.Integration.Messages;

namespace MatchMe.Candidates.Integration.Publishers
{
    public interface ICandidateCreatedPublisher
    {
        void SendMessage(CandidateCreatedMessageDto MessageDto);
    }
}
