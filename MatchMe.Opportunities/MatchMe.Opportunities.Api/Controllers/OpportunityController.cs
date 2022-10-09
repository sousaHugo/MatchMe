using MatchMe.Opportunities.Application.Dto;
using MatchMe.Opportunities.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MatchMe.Opportunities.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpportunityController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOpportunityReadService _service;
        private readonly ILogger<OpportunityController> _logger;

        public OpportunityController(ILogger<OpportunityController> Logger, IMediator Mediator, IOpportunityReadService Service)
        {
            _logger = Logger;
            _mediator = Mediator;
            _service = Service;
        }

        [HttpGet]
        public async Task<ActionResult<OpportunityGetDto>> GetAllAsync()
        {
            var opportunities = await _service.GetAllAsync();

            return Ok(opportunities);
        }
        
        [HttpGet("{Id:long}")]
        public async Task<ActionResult<IEnumerable<OpportunityDto>>> GetByIdAsync([FromRoute] long Id)
        {
            var opportunity = await _service.GetByIdAsync(Id);

            if (opportunity is null)
                return NotFound();

            return Ok(opportunity);
        }
        [HttpGet("{OpportunityId:long}/Skills")]
        public async Task<ActionResult<IEnumerable<OpportunitySkillDto>>> GetSkillsAsync([FromRoute] long OpportunityId)
        {
            var opportunitySkills = await _service.GetSkillsByOpportunityIdAsync(OpportunityId);

            return Ok(opportunitySkills);
        }
    }
}
