using ATM.Domain.Interfaces.Repostories;
using ATM.Domain.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Infrastructure.Repsotories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IFileRepository<User>? _fileRepository;
        private List<User> _users = new();


        public Repository(IFileRepository<User> file)
        {
            _fileRepository = file;
        }

        public async Task InitializeAsync()
        {
            _users = await _fileRepository.ReadAllLinesAsync() ?? new List<User>();
        }
        
    }
}
