using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Entities.Shared;

namespace Vnsf.Data.Entities
{
    public abstract class Person
    {
        public Guid Id { get; set; }
        public FullName FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool Gender { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public virtual UserAccount Account { get; set; }

    }

    public class FullName : ValueObject<FullName>
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
    }
}
