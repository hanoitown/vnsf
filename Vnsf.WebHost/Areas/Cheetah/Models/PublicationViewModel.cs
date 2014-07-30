using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Cheetah.Models
{
    public class PublicationViewModel : IMapFrom<Publication>
    {
        public Guid Id { get; set; }
        public string ISSN { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string Authors { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }


    }
}