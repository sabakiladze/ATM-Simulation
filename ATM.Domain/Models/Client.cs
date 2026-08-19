using ATM.Domain.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Models
{
    public class Client : User
    {
        public Client(string username, string passwordHash) : base(username, passwordHash)
        {
        }
        public List<Account> Accounts { get; } = new List<Account>();

        
         

        // აქ იმიტომ ხდება ექაუნთების შემოწმება რომ ექაუნთი კლიენტს აქვ და მან იცის, ექაუნთმა არ იცის. ექაუნთმა იცის ბალანსი რის გამოც მისი შემოწმება ექაუნთის კლასში ხდება, თუ
        // დავაკვირდებით მე amount პარამეტრს გადავცემ აქ ექაუნთის მეთოდებს და ისინი შეამოწმებენ.
        public void Withdraw(Account account, decimal amount)
        {
            if(!Accounts.Contains(account))
            {
                throw new AccountDoesNotExistsException("The specified account does not belong to this client.");
            }
            account.Withdraw(amount);
        }
        public void Deposit(Account account, decimal amount)
        {
                       if(!Accounts.Contains(account))
            {
                throw new AccountDoesNotExistsException("The specified account does not belong to this client.");
            }
            account.Deposit(amount);
        }
       public void TransferMoney(Account fromAccount, Account toAccount, decimal amount)
        {
            if(!Accounts.Contains(fromAccount))
            {
                throw new AccountDoesNotExistsException("The specified source account does not belong to this client.");
            }
            if(toAccount is null) 
            {
                throw new AccountDoesNotExistsException("The specified destination account does not exist.");
            }
            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);
        }


        // ექაუნთის წაშლა და დამატება სერვისში უნდა მოხდეს ლოგიკურად, ამ მეთოდებს სერვისში გამოვიყენებ და იქ შევქმნი შექმნას და წაშლის მეთოდებს.
        public Account OpenNewAccount()
        {
            var account = new Account(this);
            Accounts.Add(account);
            return account;

        }
        public void CloseAccount(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            if (!Accounts.Contains(account))
                throw new AccountDoesNotExistsException(nameof(account));
            if (account.Balance != 0)
                throw new InvalidOperationException("Cannot close an account with a non-zero balance.");
            if(Accounts.Count <= 1)
                throw new ThisIsYourOnlyAccountException("Cannot close the last account of the client.");
            Accounts.Remove(account);
        }
        public void RequestLoan(Account account, decimal amount)
        {
            if(!Accounts.Contains(account))
            {
                throw new AccountDoesNotExistsException("The specified account does not belong to this client.");
            }
           
        }
    }
}
