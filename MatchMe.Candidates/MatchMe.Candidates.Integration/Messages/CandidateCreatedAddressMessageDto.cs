namespace MatchMe.Candidates.Integration.Messages
{
    public class CandidateCreatedAddressMessageDto
    {
        public CandidateCreatedAddressMessageDto(string Street, string City, string State, string PostCode, string Country)
        {
            this.Street = Street;
            this.City = City;
            this.State = State;
            this.PostCode = PostCode;
            this.Country = Country;
        }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
}
