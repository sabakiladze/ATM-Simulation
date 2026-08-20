using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Interfaces.Services
{
    public  interface IAuthService
    {
        Task SignUpAsync(string username, string password);
        Task LogInAsync(string username, string password);
        void Logout();
        Task DeleteProfile();
    }
}
