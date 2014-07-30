using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.Principle
{
    public class UserPublication
    {
        public Guid Id { get; set; }
        public virtual Publication Publication { get; set; }
        public virtual UserProfile Profile { get; set; }
        public bool MainAuthor { get; set; }

        public static UserPublication New(bool mainAuthor, string issn, string title, string brief, string authors, string publisher, DateTime publishDate)
        {
            return new UserPublication()
            {
                Id = Guid.NewGuid(),                
                Publication = Publication.New(issn, title, brief, authors, publisher, publishDate)
            };
        }
    }
}
