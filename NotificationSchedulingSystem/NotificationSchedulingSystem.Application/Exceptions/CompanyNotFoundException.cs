using NotificationSchedulingSystem.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Application.Exceptions
{
    public class CompanyNotFoundException : NSException
    {
        public Guid Id { get; }

        public CompanyNotFoundException(Guid id) : base($"Company with ID '{id}' was not found.")
            => Id = id;
    }
}
