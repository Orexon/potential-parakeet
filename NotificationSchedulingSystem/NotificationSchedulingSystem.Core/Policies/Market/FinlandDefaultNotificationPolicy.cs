using NotificationSchedulingSystem.Core.CompanyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Core.Policies.Market
{
    internal class FinlandDefaultNotificationPolicy : ICompanyPolicy
    {

        public bool IsApplicable(PolicyData data)
            => data.Market is CompanyAggregate.Market.Finland && data.CompanyType is not CompanyType.Large;
       
        public IEnumerable<Notification> GenerateNotifications(PolicyData data)
            => new List<Notification>
            {
                //No schedule.
            };
    }
}