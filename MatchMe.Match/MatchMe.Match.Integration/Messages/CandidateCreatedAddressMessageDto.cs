namespace MatchMe.Match.Integration.Messages
{
    public class CandidateCreatedAddressMessageDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
}
