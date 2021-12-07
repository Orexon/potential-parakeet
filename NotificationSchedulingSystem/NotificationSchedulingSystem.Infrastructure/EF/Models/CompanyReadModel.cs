using NotificationSchedulingSystem.Core.CompanyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Infrastructure.EF.Models
{
    internal class CompanyReadModel
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string CompanyNumber { get; set; }
        public CompanyType CompanyType { get; set; }
        public Market Market { get; set; }
        public ICollection<NotificationReadModel> Notifications { get; set; }

    }
}
