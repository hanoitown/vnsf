using System;
using System.Collections.Generic;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities.CRM
{
    public class Certification
    {
        public int Id { get; set; }
        public int FieldId { get; set; }
        public int TitleId { get; set; }
        public int IsserId { get; set; }

        public Field Major { get; set; }
        public Organization Issuer { get; set; }
        public NameTitle Degree { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Finish { get; set; }
        public bool Awarded { get; set; }

        public ICollection<CertificationLocalized> CertificationLocalizeds { get; set; }
    }

    public class CertificationLocalized
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public string Name { get; set; }
        public Certification Certification { get; set; }
        public Culture Culture { get; set; }
    }
}