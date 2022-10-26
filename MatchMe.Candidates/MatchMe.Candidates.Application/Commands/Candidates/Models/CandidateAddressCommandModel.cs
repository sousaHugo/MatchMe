namespace MatchMe.Candidates.Application.Commands.Candidates.Models
{
    public record CandidateAddressCommandModel(string Street, 
                                            string City, 
                                            string State, 
                                            string PostCode, 
                                            string Country);
}
