using MassTransit;
using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Integration.Opportunities;
using MatchMe.Opportunities.Application.Services;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.Factories;
using MatchMe.Opportunities.Domain.Repositories;
using MatchMe.Opportunities.Integration.Publishers;

namespace MatchMe.Opportunities.Application.Commands.Handlers
{
 
    public class CreateOpportunityCommandHandler : ICommandHandler<CreateOpportunityCommand, long>
    {
        private readonly IOpportunityRepository _opportunityRepository;
        private readonly IOpportunityFactory _opportunityFactory;
        private readonly IOpportunityReadService _opportunityReadService;
        private readonly IOpportunityCreatedPublisher _publisher;
        public CreateOpportunityCommandHandler(IOpportunityFactory opportunityFactory, IOpportunityReadService OpportunityReadService, 
            IOpportunityRepository OpportunityRepository, IOpportunityCreatedPublisher Publisher)
        {
            _opportunityFactory = opportunityFactory;
            _opportunityReadService = OpportunityReadService;
            _opportunityRepository = OpportunityRepository;
            _publisher = Publisher;
        }

        public async Task<long> Handle(CreateOpportunityCommand Request, CancellationToken CancellationToken)
        {
            if(Request.OpportunityCreateDto is null)
                throw new ApplicationEntityInvalidException(nameof(Opportunity));

            if (await _opportunityReadService.ExistsByTitleAsync(Request.OpportunityCreateDto.Title))
                throw new ApplicationEntityAlreadyExistsException(nameof(Opportunity), "Title", Request.OpportunityCreateDto.Title);

            var opportunityDto = Request.OpportunityCreateDto;

            var opportunity = _opportunityFactory
                .Create(opportunityDto.Title, opportunityDto.Description, opportunityDto.ClientId, opportunityDto.Responsible, opportunityDto.Location,
                opportunityDto.BeginDate, opportunityDto.EndDate, opportunityDto.MinSalaryYear, opportunityDto.MaxSalaryYear, opportunityDto.MinExperienceMonth,
                opportunityDto.MaxExperienceMonth);

            await _opportunityRepository.AddAsync(opportunity, CancellationToken);
            _ = _publisher.SendAsync(new OpportunityCreatedDto(opportunity.Id), CancellationToken);
            
            return opportunity.Id;
        }
    }
}
