using NotificationSchedulingSystem.Application.Exceptions;
using NotificationSchedulingSystem.Core.CompanyAggregate;
using NotificationSchedulingSystem.Core.Repositories;
using NotificationSchedulingSystem.Shared.Commands;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Application.Commands.Handlers
{
    internal sealed class AddNotificationHandler : ICommandHandler<AddNotification>
    {
        private readonly ICompanyRepository _repository;

        public AddNotificationHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(AddNotification command)
        {
            var company = await _repository.GetByIdAsync(command.CompanyId);

            if (company is null)
            {
                throw new CompanyNotFoundException(command.CompanyId);
            }

            var notification = new Notification(command.SendDate);
            company.AddNotification(notification);

            await _repository.UpdateAsync(company);
        }
    }
}
