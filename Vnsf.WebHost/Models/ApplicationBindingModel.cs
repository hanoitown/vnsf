using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Account;

namespace Vnsf.WebHost.Models
{
    public class ApplicationBindingModel
    {
        public Application application { set; get; }
        public UserAccount User { get; set; }
        public Opportunity Opportunity { get; set; }
        public List<Category> Documents { get; set; }

        public ApplicationBindingModel(Application application, UserAccount user, Opportunity opportunity, IEnumerable<Category> documents)
        {
            this.User = user;
            this.Opportunity = opportunity;
            this.Documents = new List<Category>(documents);
        }
    }
}