using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Entities.Security;


namespace Vnsf.Data.Entities
{
    public class DocShare
    {
        public Guid Id { get; set; }
        public DateTime ExpireDate { get; set; }
        public string SecurityCode { get; set; }
        public virtual Doc Document { get; set; }
        public virtual Permission Right { get; set; }
        public virtual UserAccount Account { get; set; }        

    }
}
