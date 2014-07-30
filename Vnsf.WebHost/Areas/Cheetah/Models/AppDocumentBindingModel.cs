using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class AppDocumentBindingModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public HttpPostedFileBase File { get; set; }

        [HiddenInput]
        public Guid AppFormId { get; set; }
    }
}