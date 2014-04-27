using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class Classification : BaseBusiness
    {
        //e.g. for Banking, Research, Local, Industry
        public virtual ICollection<Category> Categories { get; set; }

        public Classification()
            : base()
        {
            this.Categories = new List<Category>();
        }

        public virtual void Init()
        {
            this.Id = Guid.NewGuid();
            this.Name = "Test";
        }

        public virtual void AddCategory(Category item)
        {
            if (!this.Categories.Contains(item))
                this.Categories.Add(item);
        }

        public virtual IEnumerable<Category> GetCategoryById(Guid Id)
        {
            return this.Categories.Where(c => c.Classification.Id == Id);
        }
    }
}
