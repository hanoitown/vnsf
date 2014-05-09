using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vnsf.WebHost.Models.Document
{
    public class DocumentsSelectionViewModel
    {
        public List<SelectDocumentBindingModel> Documents { get; set; }
        public DocumentsSelectionViewModel()
        {
            Documents = new List<SelectDocumentBindingModel>();
        }

        public IEnumerable<Guid> GetSelectedIds()
        {
            return (from d in this.Documents where d.Selected select d.Id).ToList();
        }
    }
}