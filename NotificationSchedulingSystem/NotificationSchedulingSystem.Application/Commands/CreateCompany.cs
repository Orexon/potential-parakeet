using NotificationSchedulingSystem.Core.CompanyAggregate;
using NotificationSchedulingSystem.Shared.Commands;
using System;
using System.Collections.Generic;

namespace NotificationSchedulingSystem.Application.Commands
{
    public record CreateCompany(Guid CompanyId, string Name, string CompanyNumber, string CompanyType, string Market) : ICommand;

}
