using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Models
{
    public class PostDisplayModel : IMapFrom<Post>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string CategoryName { get; set; }

    }
}