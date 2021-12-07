using NotificationSchedulingSystem.Application.DTO;
using NotificationSchedulingSystem.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Application.Queries
{
    public class GetSchedule : IQuery<ScheduleDTO>
    {
        public Guid CompanyId { get; set; }
    }
}
