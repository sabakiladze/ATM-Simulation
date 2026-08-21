using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Interfaces.Repostories
{
    public interface IRepository<T> where T : class 
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveAsync(T entity);
        Task DeleteAsync(Guid id);

    }

}
