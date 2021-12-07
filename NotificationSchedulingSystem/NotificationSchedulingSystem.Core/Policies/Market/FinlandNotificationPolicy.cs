using NotificationSchedulingSystem.Core.CompanyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Core.Policies.Market
{
    internal class FinlandNotificationPolicy : ICompanyPolicy
    {
        public bool IsApplicable(PolicyData data)
            => data.Market is CompanyAggregate.Market.Finland && data.CompanyType is CompanyType.Large;

        public IEnumerable<Notification> GenerateNotifications(PolicyData data)
            => new List<Notification>
            {
                new Notification(DateTime.UtcNow.Date.AddDays(1)),
                new Notification(DateTime.UtcNow.Date.AddDays(5)),
                new Notification(DateTime.UtcNow.Date.AddDays(10)),
                new Notification(DateTime.UtcNow.Date.AddDays(15)),
                new Notification(DateTime.UtcNow.Date.AddDays(20)),
            };
    }
}
