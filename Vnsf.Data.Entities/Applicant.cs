using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Vnsf.Data.Entities.Account;

namespace Vnsf.Data.Entities
{
    public class Applicant : Person
    {
        
        public virtual UserAccount LoginAccount { get; set; }

        public Applicant(UserAccount account)
        {
            this.Contact = new Contact();
            Contact.Email = account.Email;
        }
    }
}
