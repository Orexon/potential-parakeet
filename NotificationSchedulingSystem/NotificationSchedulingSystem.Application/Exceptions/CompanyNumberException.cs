using NotificationSchedulingSystem.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Application.Exceptions
{
    public class CompanyNumberException : NSException
    {
        public string CompanyNumber { get; }

        public CompanyNumberException(string companyNumber) : base($"Company number:'{companyNumber}' can only contain numbers & must be 10 numbers long")
            => CompanyNumber = companyNumber;
    }
}
