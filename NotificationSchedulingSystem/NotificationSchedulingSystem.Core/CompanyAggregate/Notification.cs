using Ardalis.GuardClauses;
using NotificationSchedulingSystem.Shared;
using System;
using System.Globalization;

namespace NotificationSchedulingSystem.Core.CompanyAggregate
{
    public class Notification
    {
        public DateTime SendDate { get; }

        public Notification(DateTime sendDate)
        {
            SendDate = Guard.Against.OutOfRange(sendDate, nameof(sendDate), DateTime.UtcNow.Date.AddDays(-1), DateTime.UtcNow.Date.AddDays(31));
        }

        public override string ToString()
        {
            
            return $"{SendDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}";
        }
    }
}