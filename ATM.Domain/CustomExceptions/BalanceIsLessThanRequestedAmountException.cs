using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.CustomExceptions
{
    [Serializable]

    public class BalanceIsLessThanRequestedAmountException : Exception 
    {
        public BalanceIsLessThanRequestedAmountException() : base("Balance is less than requested amount.") { }
        public BalanceIsLessThanRequestedAmountException(string message) : base(message) { }
        public BalanceIsLessThanRequestedAmountException(string message, Exception inner):base(message, inner) { }
        
    }
}
