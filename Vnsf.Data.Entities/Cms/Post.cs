using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Cms;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Content { get; set; }
        public PostStatus Status { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<PostLocalized> Locales { get; set; }

        public Post()
        {
            Locales = new List<PostLocalized>();
        }

    }

    public class PostLocalized
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Content { get; set; }
        public virtual Culture DestCulture { get; set; }
        public virtual Post Post { get; set; }
    }

    public enum PostStatus
    {
        Published,
        Pendding
    }
}
