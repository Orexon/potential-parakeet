using NotificationSchedulingSystem.Application.Exceptions;
using NotificationSchedulingSystem.Core.Repositories;
using NotificationSchedulingSystem.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Application.Commands.Handlers
{
    internal sealed class DeleteCompanyHandler : ICommandHandler<DeleteCompany>
    {
        private readonly ICompanyRepository _repository;

        public DeleteCompanyHandler(ICompanyRepository repository)
            => _repository = repository;

        public async Task HandleAsync(DeleteCompany command)
        {
            var company = await _repository.GetByIdAsync(command.CompanyId);

            if (company is null)
            {
                throw new CompanyNotFoundException(command.CompanyId);
            }

            await _repository.DeleteAsync(company);
        }
    }
}
