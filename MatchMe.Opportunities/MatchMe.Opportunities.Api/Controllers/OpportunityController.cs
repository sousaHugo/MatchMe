using MatchMe.Opportunities.Application.Commands;
using MatchMe.Opportunities.Application.Dto.Opportunity;
using MatchMe.Opportunities.Application.Dto.Opportunity.Extensions;
using MatchMe.Opportunities.Application.Dto.OpportunitySkill;
using MatchMe.Opportunities.Application.Mapping;
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

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<OpportunityDto>>> GetAllAsync()
        {
            var opportunities = await _service.GetAllAsync();

            return Ok(opportunities);
        }
        
        [HttpGet("GetById/{Id:long}")]
        public async Task<ActionResult<OpportunityDto>> GetByIdAsync([FromRoute] long Id)
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
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] OpportunityCreateDto RequestDto)
        {
            var requestValidation = RequestDto.Validate();

            if (!requestValidation.IsValid)
                return BadRequest(requestValidation.Response);

            var createdOpportunity = await _mediator.Send(RequestDto.AsCreateOpportunityCommand());

            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdOpportunity }, RequestDto);
        }
        [HttpPost("CreateWithDetails")]
        public async Task<IActionResult> CreateWithDetailsAsync([FromBody] OpportunityCreateWithDetailsDto RequestDto)
        {
            var requestValidation = RequestDto.Validate();

            if (!requestValidation.IsValid)
                return BadRequest(requestValidation.Response);

            var createdOpportunity = await _mediator.Send(RequestDto.AsCreateOpportunityWithDetailsCommand());

            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdOpportunity }, RequestDto);
        }
        [HttpPut("UpdateWithDetailsAsync/{Id:long}")]
        public async Task<IActionResult> UpdateWithDetailsAsync(long Id, [FromBody] OpportunityUpdateWithDetailsDto RequestDto)
        {
            if (!await _service.ExistsByIdAsync(Id))
                return NotFound();

            var requestValidation = RequestDto.Validate(Id);
            if (!requestValidation.IsValid)
                return BadRequest(requestValidation.Response);


            await _mediator.Send(RequestDto.AsUpdateOpportunityCommand());

            return NoContent();
        }
        [HttpDelete("Delete/{Id:long}")]
        public async Task<IActionResult> DeleteAsync(long Id)
        {
            if (!await _service.ExistsByIdAsync(Id))
                return NotFound();

            await _mediator.Send(new DeleteOpportunityCommand(Id));

            return NoContent();
        }
    }
}
