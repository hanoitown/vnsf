using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Account;

namespace Vnsf.Data.Entities
{
    public class Doc : BaseAudit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
        public bool IsFolder { get; set; }
        public string Path { get; set; }

        public virtual Doc Container { get; set; }
        public virtual ICollection<Doc> Children { get; set; }
        public virtual ICollection<DocShare> Shares { get; set; }
        public virtual ICollection<DocProtection> Rights { set; get; }
        public Doc()
        {
            Shares = new List<DocShare>();
            Rights = new List<DocProtection>();
            Children = new List<Doc>();
        }

        public static Doc Create(string name, string description, string contentType, int contentLength, bool isFolder, string path, Doc container, UserAccount owner)
        {
            if (isFolder)
                return CreateFolder(name, description, contentType, contentLength, path, container, owner);
            else
                return new Doc
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Description = description,
                    IsFolder = false,
                    Path = path,
                    Container = container,
                    Created = DateTime.Now,
                    CreatedBy = owner,
                    LastUpdated = DateTime.Now,
                    LastUpdatedBy = owner
                };
        }

        public static Doc CreateFolder(string name, string description, string contentType, int contentLength, string path, Doc container, UserAccount owner)
        {
            return new Doc
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Path = path,
                Container = container,
                IsFolder = true,
                Created = DateTime.Now,
                CreatedBy = owner,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = owner
            };
        }
    }
}
