using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class AppDocumentViewModel : IMapFrom<ApplicationDocument>
    {
        public Guid Id { get; set; }
        public Guid FormId { get; set; }
        public string FormCode { get; set; }
        public string FormName { get; set; }
        public AppFormViewModel Form { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }

    }
}