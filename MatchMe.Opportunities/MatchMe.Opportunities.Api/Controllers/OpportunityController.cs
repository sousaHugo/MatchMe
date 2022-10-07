using MatchMe.Common.Shared.Commands;
using MatchMe.Opportunities.Application.Commands;
using MatchMe.Opportunities.Application.Dto;
using MatchMe.Opportunities.Infrastructure.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MatchMe.Opportunities.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpportunityController : ControllerBase
    {
        //private readonly ICommandDispatcher _commandDispatcher;
        //private readonly IQueryDispatcher _queryDispatcher;

        public OpportunityController()
        {
            //_commandDispatcher = CommandDispatcher;
            //_queryDispatcher = QueryDispatcher;
        }

        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<OpportunityDto>> Get([FromRoute]GetOpportunityQuery query)
        {
        //    var result = await _queryDispatcher.QueryAsync(query);

        //    if (result is null)
        //        return NotFound();

        //    return Ok(result);

            return NotFound();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OpportunityDto>>> Get([FromRoute] SearchOpportunitiesQuery query)
        {
            //var result = await _queryDispatcher.QueryAsync(query);

            //if (result is null)
            //    return NotFound();

            //return Ok(result);

            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<OpportunityDto>>> Post([FromBody] CreateOpportunityWithSkills command)
        {
            //await _commandDispatcher.DispatchAsync(command);

            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }
        //[HttpPut("{OpportunityId}/skills")]
        //public async Task<ActionResult<IEnumerable<OpportunityDto>>> Put([FromBody] AddSkill command)
        //{
        //    await _commandDispatcher.DispatchAsync(command);

        //    return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        //}
    }
}
