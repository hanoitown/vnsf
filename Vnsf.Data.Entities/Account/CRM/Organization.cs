using System.Collections.Generic;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities.CRM
{
    public class Organization
    {
        public int Id { get; set; }
        public bool Registered { get; set; } // registered in the system by admin
        public OrgType OrgType { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Web { get; set; }
        public Attached Logo { get; set; }

        public ICollection<OrganizationLocalized> OrganizationLocalizeds { get; set; }
    }

    public class OrganizationLocalized
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public string Name { get; set; }
        public Organization Organization { get; set; }
        public Culture Culture { get; set; }

    }

    public enum OrgType
    {
        Gov = 1,
        Private = 2,
        Jsc = 3
    }
}