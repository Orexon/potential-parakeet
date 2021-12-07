using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Core.CompanyAggregate.Guards
{
    public static class CompanyGuardExtensions
    {
        public static T SpecificNumbers<T>(this IGuardClause guardClause, T input, string parameterName, string? message = null) where T : IComparable, IComparable<T>
        {
            Regex r = new(@"^[0-9]{10}$");

            if(!r.IsMatch(input.ToString()))
            {
                throw new ArgumentException(message ?? "Company number should 10 numbers long");
            }

            return input;
        }
    }
}
