using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Interfaces.Repostories
{
    public interface IFileRepository<T>
    {
        Task<List<T>> ReadAllLinesAsync();
        Task SaveAllAsync(List<T> data);
    }
}
