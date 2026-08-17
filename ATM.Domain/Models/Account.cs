using ATM.Domain.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Models
{
    public class Account
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Client Owner { get; set; }
        public decimal Balance { get; private set; } = 0;

        public Account(Client owner)
        {
            Owner = owner ?? throw new ClientAccountDoesNotExistsException(nameof(owner));
        }
        public void Deposit(decimal amount)
        {
            {
                if(amount<=0)
                {
                    throw new ArgumentException("Deposit amount must be greater than zero.");
                }
                Balance += amount;
            }
        }
        // უშუალოდ აქ იმიტომ ვაკლებთ რომ ვბალანსი აქვს ექაუნთს და ამ ობიექტს ცვლის.
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }
            if (amount > Balance)
            {
                throw new BalanceIsLessThanRequestedAmountException();
            }
            Balance -= amount;
        }

    }
}
