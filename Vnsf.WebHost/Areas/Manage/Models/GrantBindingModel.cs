using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class GrantBindingModel : IMapFrom<Grant>
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }

        [DataType(DataType.MultilineText), AllowHtml]
        public string Objective { get; set; }

        [DataType(DataType.MultilineText), AllowHtml]
        public string Scope { get; set; }
        public bool IsActive { get; set; }
        public long Total { set; get; }

        public GrantBindingModel()
        {

        }


        //public GrantBindingModel(Grant grant, IEnumerable<Organization> agencies)
        //{
        //    Grant = grant;
        //    //Agencies = new SelectList(agencies.Select(a => new SelectListItem { 
        //    //    Value = a.Id.ToString(),
        //    //    Text = a.Name,
        //    //    Selected = a.Id == grant.AgencyId
        //    //}));
        //    Agencies = agencies.ToSelectList(a => a.Id.ToString(), a => a.Name, grant.Id.ToString());
        //}


    }
}