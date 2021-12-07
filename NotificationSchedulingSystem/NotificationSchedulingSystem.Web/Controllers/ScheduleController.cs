using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationSchedulingSystem.Application.DTO;
using NotificationSchedulingSystem.Application.Queries;
using NotificationSchedulingSystem.Shared.Queries;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Web.Controllers
{
    public class ScheduleController : BaseController
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public ScheduleController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        // Get: api/Schedule/id
        [HttpGet("{CompanyId}", Name = "ScheduleById")]
        public async Task<ActionResult<ScheduleDTO>> Get([FromRoute] GetSchedule query)
        {
            var result = await _queryDispatcher.QueryAsync(query);

            return OkOrNotFound(result);
        }
    }
}