using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ATM.Domain.Models
{
    public abstract class User
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string UserName { get; }
        public string PasswordHash { get; }



        protected User(string username, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty.", nameof(username));
            if (username.Length < 3 || username.Length > 20)
                throw new ArgumentException("Username must be between 3 and 20 characters.", nameof(username));
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Password hash cannot be empty.", nameof(passwordHash));

            UserName = username;
            PasswordHash = passwordHash;
        }

        [JsonConstructor]
        public User(Guid id, string userName, string passwordHash)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;

        }
       

    }
}
