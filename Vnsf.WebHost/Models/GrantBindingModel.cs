using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;

namespace Vnsf.WebHost.Models
{
    public class GrantBindingModel
    {
        public Grant Grant { get; set; }
        public IEnumerable<SelectListItem> Agencies { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Objective { get; set; }
        public int MaxDuration { get; set; }
        public double Total { set; get; }
        public int MaxAward { set; get; }
        public Guid Issuer { get; set; }
        public GrantBindingModel(Grant grant, IEnumerable<Organization> agencies)
        {
            Grant = grant;
            //Agencies = new SelectList(agencies.Select(a => new SelectListItem { 
            //    Value = a.Id.ToString(),
            //    Text = a.Name,
            //    Selected = a.Id == grant.AgencyId
            //}));
            Agencies = agencies.ToSelectList(a => a.Id.ToString(), a => a.Name, grant.Id.ToString());
        }
        public GrantBindingModel()
        {

        }
    }
}