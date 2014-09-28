using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class PostBindModel : IMapFrom<Post>
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
    }
}