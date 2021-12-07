using Microsoft.EntityFrameworkCore;
using NotificationSchedulingSystem.Application.Services;
using NotificationSchedulingSystem.Infrastructure.EF.Contexts;
using NotificationSchedulingSystem.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Infrastructure.EF.Services
{
    internal sealed class SqlCompanyReadService : ICompanyReadService
    {
        private readonly DbSet<CompanyReadModel> _companies;

        public SqlCompanyReadService(ReadDbContext context)
        {
            _companies = context.Companies;
        }

        public Task<bool> ExistsByIdAsync(Guid CompanyId)
        {
           return _companies.AnyAsync(c=>c.CompanyId == CompanyId);
        }
    }
}
