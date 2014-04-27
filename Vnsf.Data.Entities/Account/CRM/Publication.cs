using System.Collections.Generic;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities.CRM
{
    public class Publication
    {
        public int Id { get; set; }
        public PubType PubType { get; set; }
        public string Author { get; set; }
        public Organization Organization { get; set; }
        public string ISSN { get; set; }

        public ICollection<Attached> Evidents { get; set; }
        public ICollection<PublicationLocalized> PublicationLocalizeds { get; set; }
    }

    public enum PubType
    {
        ISI = 1,
        OutNonISI = 2,
        OutConference = 3,
        InConference = 4,
        Other = 5
    }

    public class PublicationLocalized
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public Profile Profile { get; set; }
        public Culture Culture { get; set; }
    }
}