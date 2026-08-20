using ATM.Domain.Interfaces.Repostories;
using ATM.Domain.Interfaces.Services;
using ATM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Application.Services
{
    public class AuthService : IAuthService

    {
        private readonly UserSession _userSession;
        private readonly IFileRepository<User> _fileRepository;
        private readonly IRepository<User> _userRepository;
        public AuthService(UserSession currentuser, IFileRepository<User> file, IRepository<User> userrepo )
        {
            _userSession = currentuser;
            _fileRepository = file;
            _userRepository = userrepo;
        }
        public async void DeleteProfile()
        {
            User user = _userSession.CurrentUser
               ?? throw new UnauthorizedAccessException();

        }

        public Task LogInAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            _userSession.CurrentUser = null;
            Console.WriteLine("Successfully logged out");
        }

        public Task SignUpAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        Task IAuthService.DeleteProfile()
        {
            throw new NotImplementedException();
        }
    }
}
