using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities.Shared;

namespace Vnsf.Data.Entities
{
    public class Address : ValueObject<Address>
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public Address()
        {

        }
    }
}
