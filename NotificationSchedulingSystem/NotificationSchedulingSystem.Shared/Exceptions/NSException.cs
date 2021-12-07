using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Shared.Exceptions
{
    public abstract class NSException : Exception  //NSException = NotificationSchedulingSystemException
    {
        protected NSException(string message) : base(message)
        {
        }
    }

}
