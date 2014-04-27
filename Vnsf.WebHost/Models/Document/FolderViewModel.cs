using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vnsf.WebHost.Models.Document
{
    public class FolderViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<FolderViewModel> Folders { set; get; }
        public ICollection<DocumentViewModel> Files { get; set; }
    }
}