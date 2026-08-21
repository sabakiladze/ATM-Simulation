using ATM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Interfaces.Repostories
{
    public interface IClientRepository:IRepository<Client>
    {
        Task<Client> GetClientByNameAsync(string name);
        Task<List<Client>> GetAllClientsWhoHasLoanAsync();
        

    }
}
