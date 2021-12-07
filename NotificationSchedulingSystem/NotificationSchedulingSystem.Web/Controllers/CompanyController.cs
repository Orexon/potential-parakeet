using Microsoft.AspNetCore.Mvc;
using NotificationSchedulingSystem.Application.Commands;
using NotificationSchedulingSystem.Application.DTO;
using NotificationSchedulingSystem.Application.Queries;
using NotificationSchedulingSystem.Shared.Commands;
using NotificationSchedulingSystem.Shared.Queries;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Web.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public CompanyController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        // GET api/<AuthorController>/5
        [HttpGet("{CompanyId}", Name = "CompanyById")]
        public async Task<ActionResult<CompanyDTO>> Get([FromRoute]GetCompany query)
        {
            var result = await _queryDispatcher.QueryAsync(query);

            return OkOrNotFound(result);
        }

        // POST: api/Company
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCompany command)
        {
            await _commandDispatcher.DispatchAsync(command);

            //return CreatedAtRoute("CompanyById", new { id = command.Id }, null);
            return CreatedAtAction(nameof(Get), new { CompanyId = command.CompanyId }, null);
        }

        [HttpPut("{CompanyId}/notifications")]
        public async Task<IActionResult> Put([FromBody] AddNotification command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        //api/Company/Id
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCompany command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
    }
}
