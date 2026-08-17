using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.CustomExceptions
{
    [Serializable]

    public class NotEnoughMoneyOnAccountException : Exception
    {
        public NotEnoughMoneyOnAccountException() : base("Not enough money on account.") { }
        public NotEnoughMoneyOnAccountException(string message) : base(message) { }

        public NotEnoughMoneyOnAccountException(string message, Exception inner):base(message, inner) { }
    }
}
