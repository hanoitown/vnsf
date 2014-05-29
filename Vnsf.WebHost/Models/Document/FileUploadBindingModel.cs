using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vnsf.WebHost.Models.Document
{
    public class FileUploadBindingModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public HttpPostedFileBase File { get; set; }
        [HiddenInput]
        public string Location { get; set; }

        public FileUploadBindingModel()
        {

        }

        public FileUploadBindingModel(string location)
        {
            Location = location;
        }

    }
}