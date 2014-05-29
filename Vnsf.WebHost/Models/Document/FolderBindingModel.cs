using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vnsf.WebHost.Models.Document
{
    public class FolderBindingModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [HiddenInput]
        public string Location { get; set; }

        public FolderBindingModel()
        {

        }
        public FolderBindingModel(string location)
        {
            Location = location;
        }

    }
}