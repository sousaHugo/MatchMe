using MassTransit;
using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Opportunities.Application.Mapping;
using MatchMe.Opportunities.Application.Services;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.Entities.Extensions;
using MatchMe.Opportunities.Domain.Repositories;
using MatchMe.Opportunities.Integration.Publishers;

namespace MatchMe.Opportunities.Application.Commands.Handlers
{
 
    public class CreateOpportunityCommandHandler : ICommandHandler<CreateOpportunityCommand, long>
    {
        private readonly IOpportunityRepository _opportunityRepository;
        private readonly IOpportunityReadService _opportunityReadService;
        private readonly IOpportunityCreatedPublisher _publisher;
        public CreateOpportunityCommandHandler(IOpportunityReadService OpportunityReadService, 
            IOpportunityRepository OpportunityRepository, IOpportunityCreatedPublisher Publisher)
        {
            _opportunityReadService = OpportunityReadService;
            _opportunityRepository = OpportunityRepository;
            _publisher = Publisher;
        }

        public async Task<long> Handle(CreateOpportunityCommand Request, CancellationToken CancellationToken)
        {
            if(Request is null)
                throw new ApplicationEntityInvalidException(nameof(Opportunity));

            if (await _opportunityReadService.ExistsByTitleAsync(Request.Title))
                throw new ApplicationEntityAlreadyExistsException(nameof(Opportunity), "Title", Request.Title);

            var opportunityDto = Request;

            var opportunity = Opportunity.Create(opportunityDto.Title, opportunityDto.Description, opportunityDto.ClientId, opportunityDto.Responsible,
                opportunityDto.Location, opportunityDto.BeginDate, opportunityDto.EndDate, opportunityDto.MinSalaryYear, opportunityDto.MaxSalaryYear,
                opportunityDto.MinExperienceMonth, opportunityDto.MaxExperienceMonth);

            await _opportunityRepository.AddAsync(opportunity, CancellationToken);
            
            _publisher.SendMessage(opportunity.AsOpportunityCreatedDto());
            
            return opportunity.Id;
        }
    }
}
