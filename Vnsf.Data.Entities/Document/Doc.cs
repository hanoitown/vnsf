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
                    Container = container,
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
                Container = container,
                IsFolder = true,
                Created = DateTime.Now,
                CreatedBy = owner,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = owner
            };
        }

        public IEnumerable<Doc> GetHierachy()
        {
            var list = new List<Doc>();
            list.Add(this);

            var parent = this.Container;
            while (parent != null)
            {
                list.Insert(0, parent);
                parent = parent.Container;
            }

            return list;
        }

        public void AddShare(Permission permission, UserAccount account, int effectiveDuration, string securityCode = null)
        {
            //encrypted file
            //decrypted before streaming
            var share = new DocShare
            {
                Id = Guid.NewGuid(),
                Account = account,
                SecurityCode = securityCode,
                ExpireDate = DateTime.UtcNow.AddDays(effectiveDuration)
            };
            share.Rights.Add(permission);
        }

        public void AddShare(IEnumerable<Permission> permissions, UserAccount account, int effectiveDuration, string securityCode = null)
        {
            var shares = this.Shares.Where(s => s.Account.Id == account.Id).FirstOrDefault();
            if (shares == null)
                this.Shares.Add(new DocShare
                {
                    Id = Guid.NewGuid(),
                    Account = account,
                    SecurityCode = securityCode,
                    ExpireDate = DateTime.UtcNow.AddDays(effectiveDuration)
                });

            foreach (var permission in permissions)
            {
                shares.Rights.Add(permission);
            }
        }

    }
}
