using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.CustomExceptions
{
    [Serializable]

    public class AccountDoesNotExistsException : Exception
    {
        public AccountDoesNotExistsException() : base("Account does not exist.")
        {
        }

        public AccountDoesNotExistsException(string message) : base(message)
        {
        }

        public AccountDoesNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
