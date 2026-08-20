using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Interfaces.Repostories
{
    public interface IRepository<T> where T : class 
    {
        Task<T?> GetByIdAsync(Guid Id);
        Task<IEnumerable<T>> GetAllAsync();
        
    }

}
