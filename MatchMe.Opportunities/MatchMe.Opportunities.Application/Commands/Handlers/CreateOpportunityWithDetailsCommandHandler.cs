using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Opportunities.Application.Services;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.Factories;
using MatchMe.Opportunities.Domain.Repositories;

namespace MatchMe.Opportunities.Application.Commands.Handlers
{
 
    public class CreateOpportunityWithDetailsCommandHandler : ICommandHandler<CreateOpportunityWithDetailsCommand, long>
    {
        private readonly IOpportunityRepository _opportunityRepository;
        private readonly IOpportunityFactory _opportunityFactory;
        private readonly IOpportunityReadService _opportunityReadService;

        public CreateOpportunityWithDetailsCommandHandler(IOpportunityFactory opportunityFactory, IOpportunityReadService OpportunityReadService, IOpportunityRepository OpportunityRepository)
        {
            _opportunityFactory = opportunityFactory;
            _opportunityReadService = OpportunityReadService;
            _opportunityRepository = OpportunityRepository;
        }

        public async Task<long> Handle(CreateOpportunityWithDetailsCommand Request, CancellationToken CancellationToken)
        {
            if(Request.OpportunityCreateDto is null)
                throw new ApplicationEntityInvalidException(nameof(Opportunity));

            if (await _opportunityReadService.ExistsByTitleAsync(Request.OpportunityCreateDto.Title))
                throw new ApplicationEntityAlreadyExistsException(nameof(Opportunity), "Title", Request.OpportunityCreateDto.Title);

            var opportunityDto = Request.OpportunityCreateDto;

            var opportunity = _opportunityFactory
                .Create(opportunityDto.Title, opportunityDto.Description, opportunityDto.ClientId, opportunityDto.Responsible, opportunityDto.Location,
                opportunityDto.BeginDate, opportunityDto.EndDate, opportunityDto.MinSalaryYear, opportunityDto.MaxSalaryYear, opportunityDto.MinExperienceMonth,
                opportunityDto.MaxExperienceMonth, opportunityDto.Skills
                .Select(s => new OpportunitySkill(s.Name, s.MinExperience, s.MaxExperience, s.Level, s.Mandatory)));

            await _opportunityRepository.AddAsync(opportunity, CancellationToken);

            return opportunity.Id;
        }
    }
}
