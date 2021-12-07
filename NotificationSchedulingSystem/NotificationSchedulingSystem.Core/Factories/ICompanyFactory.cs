using NotificationSchedulingSystem.Core.CompanyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Core.Factories
{
    public interface ICompanyFactory
    {
        Company Create(Guid id, string name, string companyNumber, CompanyType companyType, Market market);
        Company CreateWithNotification(Guid id, string name, string companyNumber, CompanyType companyType, Market market); 
    }
}