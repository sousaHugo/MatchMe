using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Opportunities.Application.Services;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.Entities.Extensions;
using MatchMe.Opportunities.Domain.Repositories;
using MatchMe.Opportunities.Integration.Publishers;

namespace MatchMe.Opportunities.Application.Commands.Handlers
{
 
    public class CreateOpportunityWithDetailsCommandHandler : ICommandHandler<CreateOpportunityWithDetailsCommand, long>
    {
        private readonly IOpportunityRepository _opportunityRepository;
        private readonly IOpportunityReadService _opportunityReadService;
        private readonly IOpportunityCreatedPublisher _publisher;

        public CreateOpportunityWithDetailsCommandHandler(IOpportunityReadService OpportunityReadService, 
            IOpportunityRepository OpportunityRepository, IOpportunityCreatedPublisher Publisher)
        {
            _opportunityReadService = OpportunityReadService;
            _opportunityRepository = OpportunityRepository;
            _publisher = Publisher;
        }

        public async Task<long> Handle(CreateOpportunityWithDetailsCommand Request, CancellationToken CancellationToken)
        {
            if(Request.OpportunityCreateDto is null)
                throw new ApplicationEntityInvalidException(nameof(Opportunity));

            if (await _opportunityReadService.ExistsByTitleAsync(Request.OpportunityCreateDto.Title))
                throw new ApplicationEntityAlreadyExistsException(nameof(Opportunity), "Title", Request.OpportunityCreateDto.Title);

            var opportunityDto = Request.OpportunityCreateDto;

            var opportunity = Opportunity.Create(opportunityDto.Title, opportunityDto.Description, opportunityDto.ClientId, opportunityDto.Responsible,
                opportunityDto.Location, opportunityDto.BeginDate, opportunityDto.EndDate, opportunityDto.MinSalaryYear, opportunityDto.MaxSalaryYear, 
                opportunityDto.MinExperienceMonth, opportunityDto.MaxExperienceMonth, opportunityDto.Skills
                .Select(s => new OpportunitySkill(s.Name, s.MinExperience, s.MaxExperience, s.Level, s.Mandatory)));

            await _opportunityRepository.AddAsync(opportunity, CancellationToken);

            _ = _publisher.SendAsync(opportunity.AsOpportunityCreatedDto(), CancellationToken);

            return opportunity.Id;
        }
    }
}
