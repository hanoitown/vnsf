using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vnsf.WebHost.Models.Document
{
    public class DocumentsSelectionViewModel
    {
        public List<DocumentViewModel> Documents { get; set; }
        [HiddenInput]
        public string CurrLocation { get; set; }
        public DocumentsSelectionViewModel()
        {
            Documents = new List<DocumentViewModel>();
        }

        public IEnumerable<Guid> GetSelectedIds()
        {
            return (from d in this.Documents where d.Selected select d.Id).ToList();
        }
    }
}