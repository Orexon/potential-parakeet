using Microsoft.EntityFrameworkCore;
using NotificationSchedulingSystem.Core.CompanyAggregate;
using NotificationSchedulingSystem.Core.Repositories;
using NotificationSchedulingSystem.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Infrastructure.EF.Repositories
{
    internal sealed class SqlCompanyRepository : ICompanyRepository
    {
        private readonly DbSet<Company> _companies;
        private readonly WriteDbContext _writeDbcontext;

        public SqlCompanyRepository(WriteDbContext writeDbcontext)
        {
            _companies = writeDbcontext.Companies;
            _writeDbcontext = writeDbcontext;
        }

        public Task<Company> GetByIdAsync(Guid id)
        {
            return _companies.Include("_notifications").SingleOrDefaultAsync(c => c.CompanyId == id);
        }

        public async Task AddAsync(Company company)
        {
            await _companies.AddAsync(company);
            await _writeDbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _companies.Update(company);
            await _writeDbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Company company)
        {
            _companies.Remove(company);
            await _writeDbcontext.SaveChangesAsync();
        }
    }
}
