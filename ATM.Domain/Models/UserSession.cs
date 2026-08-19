using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Models
{
    public  class UserSession
    {
        public User? CurrentUser { get; set; }
        public bool IsLoggedIn => CurrentUser != null;
       

    }
}
