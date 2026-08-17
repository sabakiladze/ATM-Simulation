using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.CustomExceptions
{
    [Serializable]

    public class ThisIsYourOnlyAccountException : Exception
    {
        public ThisIsYourOnlyAccountException() : base("Cannot close the last account of the client.")
        {
        }
        public ThisIsYourOnlyAccountException(string message) : base(message)
        {
        }
        public ThisIsYourOnlyAccountException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
