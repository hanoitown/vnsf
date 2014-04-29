using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Entities.Security;

namespace Vnsf.WebHost.Models.Document
{
    public class DocShareBindingModel
    {
        public Guid DocumenteId { get; set; }
        public IEnumerable<SelectListItem> Users { set; get; }
        public IEnumerable<SelectListItem> Permissions { set; get; }
        public DateTime ExpireDate { get; set; }
        public int SecurityCode { get; set; }

        public DocShareBindingModel(IEnumerable<UserAccount> users, IEnumerable<Permission> permissions)
        {
            Users = users.ToSelectList(u => u.Id.ToString(), u => (u.Username + u.Email), string.Empty);
            Permissions = permissions.ToSelectList(p => p.Id.ToString(), p => p.Name, string.Empty);
        }
    }
}