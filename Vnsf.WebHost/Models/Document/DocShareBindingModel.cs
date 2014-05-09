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
        public IEnumerable<SelectListItem> Permissions { set; get; }
        public DateTime ExpireDate { get; set; }
        public int SecurityCode { get; set; }

        public DocShareBindingModel(IEnumerable<Permission> permissions)
        {
            Permissions = permissions.ToSelectList(p => p.Id.ToString(), p => p.Name, string.Empty);
        }
    }
}