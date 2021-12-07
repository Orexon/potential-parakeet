using NotificationSchedulingSystem.Application.DTO;
using NotificationSchedulingSystem.Shared.Queries;
using System;

namespace NotificationSchedulingSystem.Application.Queries
{
    public class GetCompany : IQuery<CompanyDTO>
    {
        public Guid CompanyId { get; set; }
    }
}
