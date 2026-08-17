using ATM.Domain.Interfaces.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Infrastructure
{
    public class FileRepository<T> : IFileRepository<T>
    {
        private readonly string _filePath;
        public FileRepository(string filePath)
        {
            
        }
        public Task<List<T>> GetAllLineAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAllAsync(List<T> data)
        {
            throw new NotImplementedException();
        }
    }
}
