using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class Category
    {
        public static Category Create(string name, string description, int displayOrder, int depth, Classification clas, Category parent)
        {
            return new Category()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                DisplayOrder = displayOrder,
                Depth = depth,
                Classification = clas,
                Parent = parent
            };
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public int Depth { get; set; }
        public virtual Classification Classification { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }

        public Category()
        {
            Children = new List<Category>();
        }
        public Category(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }



    }
}
