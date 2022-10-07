using MatchMe.Common.Shared.Commands;
using MatchMe.Opportunities.Application.Exceptions;
using MatchMe.Opportunities.Application.Services;
using MatchMe.Opportunities.Domain.Factories;
using MatchMe.Opportunities.Domain.Repositories;
using MatchMe.Opportunities.Domain.ValueObjects;
using MediatR;

namespace MatchMe.Opportunities.Application.Commands.Handlers
{
 
    public class CreateOpportunityWithSillsHandler : ICommandHandler<CreateOpportunityWithSkills, bool>
    {
        private readonly IOpportunityRepository _opportunityRepository;
        private readonly IOpportunityFactory _opportunityFactory;
        private readonly IOpportunityReadService _opportunityReadService;

        public CreateOpportunityWithSillsHandler(IOpportunityFactory opportunityFactory, IOpportunityReadService OpportunityReadService, IOpportunityRepository OpportunityRepository)
        {
            _opportunityFactory = opportunityFactory;
            _opportunityReadService = OpportunityReadService;
            _opportunityRepository = OpportunityRepository;
        }

        public async Task<bool> Handle(CreateOpportunityWithSkills Request, CancellationToken CancellationToken)
        {
            var (id, title, description, skills) = Request;

            if (await _opportunityReadService.ExistsByTitleAsync(title))
                throw new OpportunityAlreadyExistsException(title);


            var opportunity = _opportunityFactory.CreateWithSkills(id, title, description, skills.Select(a => new OpportunitySkill(a.Name, a.Experience, a.Mandatory)));

            await _opportunityRepository.AddAsync(opportunity);

            return true;
        }
    }
}
