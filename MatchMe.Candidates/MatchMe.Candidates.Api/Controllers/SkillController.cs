using MatchMe.Candidates.Application.Commands.Candidates;
using MatchMe.Candidates.Application.Commands.CandidateSkills;
using MatchMe.Candidates.Application.Dto;
using MatchMe.Candidates.Application.Dto.CandidatesSkill.Extensions;
using MatchMe.Candidates.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MatchMe.Candidates.Api.Controllers
{
    [ApiController]
    [Route("api/candidate/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICandidateSkillReadService _service;

        private readonly ILogger<SkillController> _logger;
        public SkillController(ILogger<SkillController> logger, IMediator Mediator, ICandidateSkillReadService Service)
        {
            _logger = logger;
            _mediator = Mediator;
            _service = Service;
        }
        [HttpGet("{CandidateId:long}/GetSkills")]
        public async Task<ActionResult<IEnumerable<CandidateSkillGetDto>>> GetSkillsAsync(long CandidateId)
        {
            var candidateSkills = await _service.GetByCandidateIdAsync(CandidateId);

            return Ok(candidateSkills);
        }
        [HttpGet("GetById/{Id:long}")]
        public async Task<ActionResult<CandidateSkillGetDto>> GetByIdAsync([FromRoute]long Id)
        {
            var skill = await _service.GetByIdAsync(Id);

            return Ok(skill);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] CandidateSkillCreateDto RequestDto)
        {
            var requestValidation = RequestDto.Validate();

            if (!requestValidation.IsValid)
                return BadRequest(requestValidation.Response);

            var createdSkill = await _mediator.Send(new CreateCandidateSkillCommand(RequestDto));

            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdSkill }, RequestDto);
        }
        [HttpPut("Update/{Id:long}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long Id, [FromBody] CandidateSkillUpdateDto RequestDto)
        {
            var requestValidation = RequestDto.Validate(Id);

            if (!requestValidation.IsValid)
                return BadRequest(requestValidation.Response);

            await _mediator.Send(new UpdateCandidateSkillCommand(RequestDto));

            return NoContent();
        }

        [HttpDelete("Delete/{Id:long}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long Id)
        {
            var skillDto = await _service.GetByIdAsync(Id);
            if (skillDto is null)
                return NotFound();

            await _mediator.Send(new DeleteCandidateSkillCommand(skillDto.CandidateId, Id));

            return NoContent();
        }
    }
}