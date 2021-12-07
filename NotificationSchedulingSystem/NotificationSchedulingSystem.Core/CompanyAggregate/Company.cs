using Ardalis.GuardClauses;
using NotificationSchedulingSystem.Core.CompanyAggregate.Guards;
using NotificationSchedulingSystem.Shared;
using NotificationSchedulingSystem.Shared.Interfaces;
using System;
using System.Collections.Generic;

namespace NotificationSchedulingSystem.Core.CompanyAggregate
{
    public class Company : IAggregateRoot
    {
        public Guid CompanyId { get; set; }
        public string Name { get; private set; }
        public string CompanyNumber { get; private set; }
        public CompanyType CompanyType { get; private set; }
        public Market Market { get; private set; }

        private readonly List<Notification> _notifications = new();
        //Enum.IsDefined(typeof(Vehicle), "car") check type.
        private Company(Guid id, string name, string companyNumber, CompanyType companyType, Market market, List<Notification> notifications)
            : this(id,name, companyNumber, companyType, market)
        {
            _notifications = notifications;
        }

        private Company()
        {
        }

        internal Company(Guid id, string name, string companyNumber, CompanyType companyType, Market market)
        {
            CompanyId = Guard.Against.NullOrEmpty(id, nameof(id));
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            CompanyNumber = Guard.Against.SpecificNumbers(companyNumber, nameof(companyNumber));
            CompanyType = Guard.Against.Null(companyType, nameof(companyType));
            Market = Guard.Against.Null(market, nameof(market));
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                AddNotification(notification);
            }
        }
    }
}
