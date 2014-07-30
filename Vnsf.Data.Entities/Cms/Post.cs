using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class Post 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TitleShort { get; set; }
        public string Content { get; set; }
        public Category Category { get; set; }
        public DateTime PublishDate { get; set; }  
        public virtual ICollection<PostVersion> Versions { get; set; }

        public Post()
        {

        }

        /// <summary>
        /// FindById announcement by version 
        /// </summary>
        /// <param name="version">null for lastest version</param>
        /// <returns></returns>
        public PostVersion GetVersion(int? version)
        {
            if (version != null)
                return Versions.FirstOrDefault(v => v.Version == version);

            return Versions.OrderByDescending(v => v.Version).FirstOrDefault();
        }

        public void AddAVersion(PostVersion version)
        {
            var lastest = GetVersion(null);
            var max = (lastest != null) ? lastest.Version++ : 1;
            version.Version = max;
            Versions.Add(version);
        }
    }
}
