using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Infrastructure.EF.Models
{
    internal class NotificationReadModel
    {
        public Guid Id { get; set; }
        public DateTime SendDate { get; set; }

        public CompanyReadModel Company { get; set; }

    }
}
