using System.Collections.Generic;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities.CRM
{
    public class Address
    {
        public int Id { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }

        public string ZipCode { get; set; }
        public Region Region { get; set; }
        public Country Country { get; set; }
        public string Cordinate { get; set; }

        public ICollection<AddressLocalized> AddressLocalizeds { get; set; }
    }

    public class AddressLocalized
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public Address Address { get; set; }
        public Culture Culture { get; set; }
    }
}