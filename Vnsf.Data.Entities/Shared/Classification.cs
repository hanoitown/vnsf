using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities
{
    public class Classification
    {
        public static Classification New(string name, string description, string code)
        {
            return new Classification()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Code = code
            };
        }

        public virtual Guid Id { set; get; }
        public string Code { get; set; }
        public virtual string Name { set; get; }
        public virtual string Description { set; get; }
        //e.g. for Banking, Research, Local, Industry
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Grant> Grants { get; set; }
        public Classification()
        {
            Categories = new List<Category>();
            Grants = new List<Grant>();
        }
    }

}
