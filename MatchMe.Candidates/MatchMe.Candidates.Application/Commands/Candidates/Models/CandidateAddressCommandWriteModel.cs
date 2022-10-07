namespace MatchMe.Candidates.Application.Commands.Candidates.Models
{
    public record CandidateAddressCommandWriteModel(string Street, 
                                            string City, 
                                            string State, 
                                            string PostCode, 
                                            string Country);
}
