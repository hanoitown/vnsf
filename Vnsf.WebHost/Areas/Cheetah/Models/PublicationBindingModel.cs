using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Principle;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class PublicationBindingModel : IMapFrom<Publication>
    {
        //public Guid PublicationKindId { get; set; }
        [HiddenInput]
        public Guid Id { set; get; }
        public string ISSN { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string Authors { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public PublicationStatus Status { get; set; }
        public string Note { get; set; }
        [HiddenInput]
        public Guid ProfileId { get; set; }
        

    }
}
