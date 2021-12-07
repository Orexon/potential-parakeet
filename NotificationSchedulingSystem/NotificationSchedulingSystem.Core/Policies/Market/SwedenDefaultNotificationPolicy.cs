using NotificationSchedulingSystem.Core.CompanyAggregate;
using System.Collections.Generic;

namespace NotificationSchedulingSystem.Core.Policies.Market
{
    internal class SwedenDefaultNotificationPolicy : ICompanyPolicy
    {
        public bool IsApplicable(PolicyData data)
            => data.Market is CompanyAggregate.Market.Sweden && data.CompanyType is CompanyType.Large;

        public IEnumerable<Notification> GenerateNotifications(PolicyData data)
            => new List<Notification>
            {
                //No schedule.
            };
    }
}