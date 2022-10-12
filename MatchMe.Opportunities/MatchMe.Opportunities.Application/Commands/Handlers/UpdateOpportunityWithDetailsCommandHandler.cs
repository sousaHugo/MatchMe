using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Opportunities.Application.Services;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.Repositories;

namespace MatchMe.Opportunities.Application.Commands.Handlers
{
 
    public class UpdateOpportunityWithDetailsCommandHandler : ICommandHandler<UpdateOpportunityCommand, long>
    {
        private readonly IOpportunityRepository _opportunityRepository;
        private readonly IOpportunityReadService _opportunityReadService;

        public UpdateOpportunityWithDetailsCommandHandler(IOpportunityReadService OpportunityReadService, IOpportunityRepository OpportunityRepository)
        {
            _opportunityReadService = OpportunityReadService;
            _opportunityRepository = OpportunityRepository;
        }

        public async Task<long> Handle(UpdateOpportunityCommand Request, CancellationToken CancellationToken)
        {
            if (Request.OpportunityUpdateDto is null)
                throw new ApplicationEntityInvalidException(nameof(Opportunity));

            var opportunityEf = await _opportunityRepository.GetAsync(Request.OpportunityUpdateDto.Id, CancellationToken);

            if (opportunityEf == null)
                throw new ApplicationEntityNotFoundException(nameof(Opportunity), Request.OpportunityUpdateDto.Id.ToString());

            var opportunityUpdateDto = Request.OpportunityUpdateDto;

            opportunityEf.Update(opportunityUpdateDto.Title, opportunityUpdateDto.Description, opportunityUpdateDto.ClientId,
                opportunityUpdateDto.Responsible, opportunityUpdateDto.Location, opportunityUpdateDto.BeginDate, opportunityUpdateDto.EndDate,
                opportunityUpdateDto.MinSalaryYear, opportunityUpdateDto.MaxSalaryYear, opportunityUpdateDto.MinExperienceMonth,
                opportunityUpdateDto.MaxExperienceMonth, opportunityUpdateDto.Skills
                .Select(a => new OpportunitySkill(a.Id, a.Name, a.MinExperience, a.MaxExperience, a.Level, a.Mandatory)));

            await _opportunityRepository.UpdateAsync(opportunityEf, CancellationToken);

            return opportunityEf.Id;
        }
    }
}
