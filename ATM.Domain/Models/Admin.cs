using ATM.Domain.Ennums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Models
{
    public class Admin : User
    {
        public Admin(string username, string passwordHash) : base(username, passwordHash)
        {
        }

        public void AcceptLoanRequest(LoanRequest loanRequest)
        {
            if (loanRequest == null)
                throw new ArgumentNullException(nameof(loanRequest));
            if (loanRequest.Status != LoanStatus.Pending)
                throw new InvalidOperationException("Only pending loan requests can be approved.");

            loanRequest.Approve();
        }

        public void RejectLoanRequest(LoanRequest loanRequest)
        {
            if (loanRequest == null)
                throw new ArgumentNullException(nameof(loanRequest));
            if (loanRequest.Status != LoanStatus.Pending)
                throw new InvalidOperationException("Only pending loan requests can be rejected.");

            loanRequest.Reject();
        }
    }
}
