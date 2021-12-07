using NotificationSchedulingSystem.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace NotificationSchedulingSystem.Application.Commands.Handlers
{
    public class InvalidCompanyTypeException : NSException
    {
        public string Companytype { get; }

        public InvalidCompanyTypeException(string companytype) : base($"Company with with such type:'{companytype}' does not exist. Valid types: 'Large','Medium','Small'")
            => Companytype = companytype;
    }
}