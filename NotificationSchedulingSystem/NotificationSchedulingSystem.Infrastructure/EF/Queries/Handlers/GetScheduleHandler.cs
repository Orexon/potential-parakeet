using Microsoft.EntityFrameworkCore;
using NotificationSchedulingSystem.Application.DTO;
using NotificationSchedulingSystem.Application.Queries;
using NotificationSchedulingSystem.Core.Repositories;
using NotificationSchedulingSystem.Infrastructure.EF.Contexts;
using NotificationSchedulingSystem.Infrastructure.EF.Models;
using NotificationSchedulingSystem.Shared.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Infrastructure.Queries.Handlers
{
    internal class GetScheduleHandler : IQueryHandler<GetSchedule, ScheduleDTO>
    {

        private readonly DbSet<CompanyReadModel> _companies;

        public GetScheduleHandler(ReadDbContext context)
        {
            _companies = context.Companies;
        }

        public async Task<ScheduleDTO> HandleAsync(GetSchedule query)
        {
            return await _companies
                .Include(c => c.Notifications)
                .Where(c => c.CompanyId == query.CompanyId)
                .Select(c => c.AsScheduleDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();

        }
    }
}
