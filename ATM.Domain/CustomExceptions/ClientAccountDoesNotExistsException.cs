using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.CustomExceptions
{
    [Serializable]

    public class ClientAccountDoesNotExistsException :Exception
    {
        public ClientAccountDoesNotExistsException():base("Client account does not exist.")
        {
            
        }
        public ClientAccountDoesNotExistsException(string message) : base(message)
        {
            
        }
        public ClientAccountDoesNotExistsException(string message, Exception inner):base(message, inner)
        {
            
        }
    }
}
