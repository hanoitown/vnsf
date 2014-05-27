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
        [HiddenInput]
        public string Path { get; set; }
        [HiddenInput]
        public bool IsFolder { get; set; }
        [HiddenInput]
        public Guid FolderId { get; set; }
        public HttpPostedFileBase File { get; set; }

        public DocumentBindingModel()
        {

        }
        public DocumentBindingModel(string path)
        {
            Path = path;
        }
        public DocumentBindingModel(bool isFolder, string path)
        {
            IsFolder = isFolder;
            Path = path;
        }


    }
}