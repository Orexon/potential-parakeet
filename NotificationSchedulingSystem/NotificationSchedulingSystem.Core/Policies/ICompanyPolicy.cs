using NotificationSchedulingSystem.Core.CompanyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Core.Policies
{
    public interface ICompanyPolicy
    {
        bool IsApplicable(PolicyData data);
        IEnumerable<Notification> GenerateNotifications(PolicyData data);
    }
}
