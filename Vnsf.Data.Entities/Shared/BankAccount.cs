using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Shared
{
    public class BankAccount
    {
        public static BankAccount New(string accountno, string branch, BankInfo bank)
        {
            return new BankAccount()
            {
                Id = Guid.NewGuid(),
                AccountNo = accountno,
                Branch = branch,
                Bank = bank
            };
        }
        public Guid Id { get; set; }
        public string AccountNo { get; set; }
        public string Branch { get; set; }
        public virtual BankInfo Bank { get; set; }
    }
}
