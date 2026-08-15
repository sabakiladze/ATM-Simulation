using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Models
{
    public abstract class User
    {
        public Guid Id { get;} = Guid.NewGuid();
        public string UserName { get; }
        public string Email { get; set; }
        private string Password { get; set; }
        public string PasswordHash { get; set; }
        public int? VerificationCode { get; set; } = default;
        public bool IsEmailVerified { get; set; }= false;
        public DateTime? VerificationCodeExpiresAt { get; private set; }

    }
}
