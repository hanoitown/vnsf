using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Classification Classification { get; set; }
        public virtual ICollection<CategoryChild> Children { get; set; }

        public Category()
        {
            Children = new List<CategoryChild>();
        }
        public Category(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }
    }
}
