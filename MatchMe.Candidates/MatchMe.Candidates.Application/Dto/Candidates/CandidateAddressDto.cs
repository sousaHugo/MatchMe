namespace MatchMe.Candidates.Application.Dto.Candidates
{
    public class CandidateAddressDto
    {
        public CandidateAddressDto() { }
        public CandidateAddressDto(string Street, string City, string State, string PostCode, string Country)
        {
            this.Street = Street;
            this.City = City;
            this.State = State;
            this.PostCode = PostCode;
            this.Country = Country;
        }

        public CandidateAddressDto(string Address)
        {
            var splitLocalization = Address.Split(',');
            Street = splitLocalization.Length >= 1 ? splitLocalization[0] : string.Empty;
            City = splitLocalization.Length >= 2 ? splitLocalization[1] : string.Empty;
            State = splitLocalization.Length >= 3 ? splitLocalization[2] : string.Empty;
            PostCode = splitLocalization.Length >= 4 ? splitLocalization[3] : string.Empty;
            Country = splitLocalization.Length >= 5 ? splitLocalization[4] : string.Empty;
        }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
}
