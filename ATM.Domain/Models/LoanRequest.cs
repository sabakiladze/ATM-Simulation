using ATM.Domain.Ennums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Models
{
    public class LoanRequest
    {
        public Guid Id { get; }=Guid.NewGuid();
        public Client Client { get; private set; }
        public decimal Amount { get;}
        public DateTime RequestedAt { get; } = DateTime.UtcNow;
        public LoanStatus Status { get; private set; }
   
        public LoanRequest(Client client, decimal amount)
        {
            if(client == null) throw new ArgumentNullException("Invalid client", nameof(client));
            if (amount <= 0)
            {
                throw new ArgumentException("Loan amount must be greater than zero.");
            }
            Client = client;
            Amount = amount;
            Status= LoanStatus.Pending;
        }

       public void Approve()=> Status =LoanStatus.Approved;
        public void Reject()=>Status=LoanStatus.Rejected;
    }
}
