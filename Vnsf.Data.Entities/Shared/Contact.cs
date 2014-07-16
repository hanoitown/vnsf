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
        public string Mobile { get; set; }
        public string OtherEmail { get; set; }
        public string HomePhone { get; set; }
        public string Email { set; get; }
        public string Fax { get; set; }
        public Address PostalAddress { set; get; }
        public Address VisitingAddress { get; set; }

        public Contact()
        {

        }

    }


}
