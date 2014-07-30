using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Entities.Principle;
using Vnsf.Data.Entities.Shared;

namespace Vnsf.Data.Entities
{
    public class Publication
    {
        public Guid Id { set; get; }
        public string ISSN { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string Note { get; set; }
        public virtual Category Kind { get; set; }
        public string Authors { get; set; }
        public string OtherPublisher { get; set; }
        public PublicationStatus Status { get; set; }
        public DateTime PublishedDate { get; set; }

        //public virtual ICollection<UserPublication> UserPublications { get; set; }
        
        public virtual Publisher Publisher { get; set; }
        public virtual Doc Document { get; set; }


        public virtual UserProfile Profile { set; get; }
        public Publication()
        {
        }

        public static Publication New(string issn, string title, string brief, string authors, 
                                        string publisher, DateTime publishDate)
        {
            return new Publication()
            {
                Id = Guid.NewGuid(),
                ISSN = issn,
                Title = title,
                Brief = brief,
                Authors = authors,
                OtherPublisher = publisher,
                PublishedDate = publishDate
            };
        }
    }

    public enum PublicationStatus
    {
        Published,                
        AwaitingPulication,
        Accepted,
        UnderReview,
        Other
    }
}
