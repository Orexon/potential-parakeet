using NotificationSchedulingSystem.Core.CompanyAggregate;
using NotificationSchedulingSystem.Core.Policies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Core.Factories
{
    public sealed class CompanyFactory : ICompanyFactory
    {
        private readonly IEnumerable<ICompanyPolicy> _policies;

        public CompanyFactory(IEnumerable<ICompanyPolicy> policies)
            => _policies = policies;


        public Company Create(Guid id, string name, string companyNumber, CompanyType companyType, Market market)
            => new(id, name, companyNumber, companyType, market);

        public Company CreateWithNotification(Guid id, string name, string companyNumber, CompanyType companyType, Market market)
        {
            var data = new PolicyData(companyType, market);

            var applicablePolicies = _policies.SingleOrDefault(policy => policy.IsApplicable(data)); //if >1 policy => exception.

            var notifications = applicablePolicies.GenerateNotifications(data);

            var company = Create(id,name, companyNumber, companyType, market);

            company.AddNotifications(notifications);

            return company;
        }
    }
}