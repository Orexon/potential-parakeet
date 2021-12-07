using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Application.DTO
{
    public class ScheduleDTO
    {
        public Guid CompanyId { get; set; }
        public string[] Notifications { get; set; }
    }
}
