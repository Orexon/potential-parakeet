using NotificationSchedulingSystem.Core.CompanyAggregate;
using System;
using System.Collections.Generic;

namespace NotificationSchedulingSystem.Core.Policies.Market
{
    internal class SwedenNotificationPolicy : ICompanyPolicy
    {
        public bool IsApplicable(PolicyData data)
            => data.Market is CompanyAggregate.Market.Sweden && data.CompanyType is not CompanyType.Large;

        public IEnumerable<Notification> GenerateNotifications(PolicyData data)
            => new List<Notification>
            {
                new Notification(DateTime.UtcNow.Date.AddDays(1)),
                new Notification(DateTime.UtcNow.Date.AddDays(7)),
                new Notification(DateTime.UtcNow.Date.AddDays(14)),
                new Notification(DateTime.UtcNow.Date.AddDays(28)),
            };
    }
}
