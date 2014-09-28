using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Areas.Manage.Models
{
    public class PostViewModel : IMapFrom<Post>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public PostStatus Status { get; set; }
        public DateTime PublishDate { get; set; }
        public string CategoryName { get; set; }

    }
}