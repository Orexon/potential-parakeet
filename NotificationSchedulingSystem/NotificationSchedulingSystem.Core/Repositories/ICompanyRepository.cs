using NotificationSchedulingSystem.Core.CompanyAggregate;
using System;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Core.Repositories
{
    public interface ICompanyRepository
    {
        Task<Company> GetByIdAsync(Guid id);
        Task AddAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(Company company);
    }
}