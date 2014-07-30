using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vnsf.WebHost.Models.Document
{
    public class DocumentLinkModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public bool Selected { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
        public bool IsFolder { get; set; }
        public string Path { get; set; }
        public string Location { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expire { get; set; }
        public string SecurityCode { get; set; }
        public DocumentLinkModel()
        {

        }

    }
}