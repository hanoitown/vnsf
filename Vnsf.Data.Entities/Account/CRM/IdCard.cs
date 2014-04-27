using System;
using System.Collections.Generic;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities.CRM
{
    public class IdCard
    {
        public int Id { get; set; }
        public Organization Issuer { get; set; }
        public DateTime IssueDate { get; set; }
        public Region Place { get; set; }
        public string Number { get; set; }
        public CardType CardType { get; set; }

        public ICollection<IdCardLocalization> IdCardLocalizations { get; set; }
    }

    public class IdCardLocalization
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public string Name { get; set; }
        public string IssueDate { get; set; }
        public IdCard ScientistProfile { get; set; }
        public Culture Culture { get; set; }

    }

    public enum CardType
    {
        National = 1,
        Passport = 2,
        DriveLicence = 3,
        OfficeId = 4
    }


}