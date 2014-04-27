using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vnsf.WebHost.Models.Document
{
    public class DocumentBindingModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFolder { get; set; }
        public Guid? FolderId { get; set; }
        public HttpPostedFileBase File { get; set; }

    }
}