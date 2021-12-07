using NotificationSchedulingSystem.Application.Exceptions;
using NotificationSchedulingSystem.Application.Services;
using NotificationSchedulingSystem.Core.CompanyAggregate;
using NotificationSchedulingSystem.Core.Factories;
using NotificationSchedulingSystem.Core.Repositories;
using NotificationSchedulingSystem.Shared.Commands;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Application.Commands.Handlers
{
    public class CreateCompanyHandler : ICommandHandler<CreateCompany>
    {

        private readonly ICompanyRepository _repository;
        private readonly ICompanyFactory _factory;
        private readonly ICompanyReadService _readService;

        public CreateCompanyHandler(ICompanyRepository repository, ICompanyReadService readService, ICompanyFactory factory)
        {
            _repository = repository;
            _readService = readService;
            _factory = factory;
        }

        public async Task HandleAsync(CreateCompany command)
        {
            var (id, name, companyNumber, companytype, market) = command; //record attribute gives object deconstruction. Implements deconstruct. 

            if (await _readService.ExistsByIdAsync(id))
            {
                throw new CompanyAlreadyExistsException(id);
            }

            Regex r = new(@"^[0-9]{10}$");
            if (!r.IsMatch(companyNumber))
            {
                throw new CompanyNumberException(companyNumber);
            }
            if (!Enum.TryParse(companytype, out CompanyType companyType))
            {
                throw new InvalidCompanyTypeException(companytype);
            }
            if(!Enum.IsDefined(typeof(CompanyType), companyType))
            {
                throw new InvalidCompanyTypeException(companytype);
            }

            if (!Enum.TryParse(market, out Market Market))
            {
                throw new InvalidCompanyTypeException(market);
            }
            if (!Enum.IsDefined(typeof(Market), Market))
            {
                throw new InvalidCompanyTypeException(market);
            }



            var company = _factory.CreateWithNotification(id, name, companyNumber, companyType, Market);

            await _repository.AddAsync(company);
        }
    }
}
