using MatchMe.Candidates.Application.Commands.Candidates;
using MatchMe.Candidates.Application.Dto.Candidates;
using MatchMe.Candidates.Application.Dto.Candidates.Extensions;
using MatchMe.Candidates.Application.Mapping;
using MatchMe.Candidates.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MatchMe.Candidates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICandidateReadService _service;

        private readonly ILogger<CandidateController> _logger;
        public CandidateController(ILogger<CandidateController> logger, IMediator Mediator, ICandidateReadService Service)
        {
            _logger = logger;
            _mediator = Mediator;
            _service = Service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CandidateGetDto>>> GetAllAsync()
        {
            var candidates = await _service.GetAllAsync();

            return Ok(candidates);
        }
        [HttpGet("GetById/{Id:long}")]
        public async Task<ActionResult<CandidateGetDto>> GetByIdAsync(long Id)
        {
            var candidate = await _service.GetByIdAsync(Id);

            if (candidate == null)
                return NotFound();

            return Ok(candidate);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] CandidateCreateDto RequestDto)
        {
            var requestValidation = RequestDto.Validate();

            if (!requestValidation.IsValid)
                return BadRequest(requestValidation.Response);

            var createdCandidate = await _mediator.Send(RequestDto.AsCreateCandidateCommand());

            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdCandidate }, RequestDto);
        }
        [HttpPost("CreateWithDetails")]
        public async Task<IActionResult> CreateWithDetailsAsync([FromBody] CandidateCreateWithDetailsDto RequestDto)
        {
            var requestValidation = RequestDto.Validate();

            if (!requestValidation.IsValid)
                return BadRequest(requestValidation.Response);

            var createdCandidate = await _mediator.Send(RequestDto.AsCreateCandidateCommand());

            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdCandidate }, RequestDto);
        }
        [HttpPut("UpdateWithDetailsAsync/{Id:long}")]
        public async Task<IActionResult> UpdateWithDetailsAsync(long Id, [FromBody] CandidateUpdateWithDetailsDto RequestDto)
        {
            if (!await _service.ExistsByIdAsync(Id))
                return NotFound();

            var requestValidation = RequestDto.Validate();
            if (!requestValidation.IsValid)
                return BadRequest(requestValidation.Response);


            await _mediator.Send(RequestDto.AsUpdateCandidateCommand());

            return NoContent();
        }

        [HttpDelete("Delete/{Id:long}")]
        public async Task<IActionResult> DeleteAsync(long Id)
        {
            if (!await _service.ExistsByIdAsync(Id))
                return NotFound();

            await _mediator.Send(new DeleteCandidateCommand(Id));

            return NoContent();
        }
    }
}