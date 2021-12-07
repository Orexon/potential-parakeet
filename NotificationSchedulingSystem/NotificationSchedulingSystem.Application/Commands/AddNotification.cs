using NotificationSchedulingSystem.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Application.Commands
{
    public record AddNotification(Guid CompanyId, DateTime SendDate) : ICommand;
}
