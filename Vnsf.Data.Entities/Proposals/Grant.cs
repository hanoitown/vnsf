using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Shared;

namespace Vnsf.Data.Entities
{
    public class Grant : Audit
    {
        public static Grant NewGrant(string code, string name, string description, string objective, string scope, bool isActive, long total, Classification clas)
        {
            return new Grant()
            {
                Id = Guid.NewGuid(),
                Code = code,
                Name = name,
                Description = description,
                Objective = objective,
                Scope = scope,
                IsActive = isActive,
                Total = total,
                Classification = clas
            };
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Objective { get; set; }
        public string Scope { get; set; }
        public bool IsActive { get; set; }
        public long Total { set; get; }
        public virtual Classification Classification { get; set; }
        public virtual ICollection<Opportunity> Opportunities { get; set; }

        public Grant()
        {
            Opportunities = new List<Opportunity>();
        }

    }
}
