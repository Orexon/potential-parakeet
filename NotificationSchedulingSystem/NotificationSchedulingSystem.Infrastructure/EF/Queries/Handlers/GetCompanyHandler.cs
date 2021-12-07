using Microsoft.EntityFrameworkCore;
using NotificationSchedulingSystem.Application.DTO;
using NotificationSchedulingSystem.Application.Queries;
using NotificationSchedulingSystem.Core.Repositories;
using NotificationSchedulingSystem.Infrastructure.EF.Contexts;
using NotificationSchedulingSystem.Infrastructure.EF.Models;
using NotificationSchedulingSystem.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Infrastructure.Queries.Handlers
{
    internal class GetCompanyHandler : IQueryHandler<GetCompany, CompanyDTO>
    {
        private readonly DbSet<CompanyReadModel> _companies;

        public GetCompanyHandler(ReadDbContext context)
        {
            _companies = context.Companies;
        }

        public async Task<CompanyDTO> HandleAsync(GetCompany query)
        {
            return 
                 await _companies
                .Include(c => c.Notifications)
                .Where(c => c.CompanyId == query.CompanyId)
                .Select(c => c.AsCompanyDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
            

    }
}
