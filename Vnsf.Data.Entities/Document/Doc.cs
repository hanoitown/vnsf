using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Entities.Security;

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

        public virtual Doc Parent { get; set; }
        public virtual ICollection<Doc> Children { get; set; }
        public virtual ICollection<DocShare> Shares { get; set; }
        public virtual ICollection<DocProtection> Rights { set; get; }
        public Doc()
        {
            Shares = new List<DocShare>();
            Rights = new List<DocProtection>();
            Children = new List<Doc>();
        }

        public static Doc CreateFile(string name, string description, bool isFolder, string path, Doc container, UserAccount owner)
        {
            if (isFolder)
                return CreateFolder(name, description, path, container, owner);
            else
                return new Doc
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Description = description,
                    IsFolder = false,
                    Path = path,
                    Parent = container,
                    Created = DateTime.Now,
                    CreatedBy = owner,
                    LastUpdated = DateTime.Now,
                    LastUpdatedBy = owner
                };
        }

        public static Doc CreateFolder(string name, string description, string path, Doc container, UserAccount owner)
        {
            return new Doc
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Path = path,
                Parent = container,
                IsFolder = true,
                Created = DateTime.Now,
                CreatedBy = owner,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = owner
            };
        }
        //public static Doc CreateFolder(UserAccount account)
        //{
        //    return new Doc
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = account.Username.GetHashCode().ToString(),
        //        Description = string.Format("Personal folder for user {0}", account.Username),
        //        Path = BaseUrl + 
        //    };
        //}

        public IEnumerable<Doc> GetHierachy()
        {
            var list = new List<Doc>();
            list.Add(this);

            var parent = this.Parent;
            while (parent != null)
            {
                list.Insert(0, parent);
                parent = parent.Parent;
            }

            return list;
        }

        public void AddShare(Permission permission, int effectiveDuration, string securityCode = null)
        {
            //encrypted file
            //decrypted before streaming
            Shares.Add(new DocShare
            {
                Id = Guid.NewGuid(),
                SecurityCode = securityCode,
                ExpireDate = DateTime.UtcNow.AddDays(effectiveDuration),
                Right = permission
            });

        }


    }
}
