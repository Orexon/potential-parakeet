using NotificationSchedulingSystem.Shared.Commands;
using System;

namespace NotificationSchedulingSystem.Application.Commands
{
    public record DeleteCompany(Guid CompanyId) : ICommand;
}
