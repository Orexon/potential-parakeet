using NotificationSchedulingSystem.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Application.Exceptions
{
    public class CompanyAlreadyExistsException : NSException
    {
        public Guid Id { get; }

        public CompanyAlreadyExistsException(Guid id) : base($"Company with id: '{id}' already exists.")
        {
            Id = id;
        }
    }
}
