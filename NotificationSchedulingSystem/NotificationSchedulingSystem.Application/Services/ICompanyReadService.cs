using System;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Application.Services
{
    public interface ICompanyReadService
    {
        Task<bool> ExistsByIdAsync(Guid CompanyId);

    }
}
