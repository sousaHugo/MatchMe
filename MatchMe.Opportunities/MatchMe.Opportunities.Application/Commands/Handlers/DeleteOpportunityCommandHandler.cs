using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Opportunities.Application.Services;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.Repositories;
using MediatR;

namespace MatchMe.Opportunities.Application.Commands.Handlers
{
 
    public class DeleteOpportunityCommandHandler : ICommandHandler<DeleteOpportunityCommand, Unit>
    {
        private readonly IOpportunityRepository _opportunityRepository;

        public DeleteOpportunityCommandHandler(IOpportunityRepository OpportunityRepository)
        {
            _opportunityRepository = OpportunityRepository;
        }

        public async Task<Unit> Handle(DeleteOpportunityCommand Request, CancellationToken CancellationToken)
        {
            var opportunityEf = await _opportunityRepository.GetAsync(Request.Id, CancellationToken);

            if(opportunityEf is null)
                throw new ApplicationEntityNotFoundException(nameof(Opportunity), Request.Id.ToString());

            await _opportunityRepository.DeleteAsync(opportunityEf, CancellationToken);

            return new Unit();
        }
    }
}
