using NotificationSchedulingSystem.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Application.Exceptions
{
    public class InvalidMarketException : NSException
    {
        public string Market { get; }

        public InvalidMarketException(string market) : base($"Market type:'{market}' is invalid. Valid types: 'Denmark','Norway','Sweden','Finland'")
            => Market = market;
    }
}
