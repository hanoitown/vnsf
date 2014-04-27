using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Shared;

namespace Vnsf.Data.Entities
{
    public class Contact : ValueObject<Contact>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public Address PostalAddress { set; get; }
        public Address VisitingAddress { get; set; }
        public string Website { get; set; }

        public Contact()
        {

        }

    }


}
