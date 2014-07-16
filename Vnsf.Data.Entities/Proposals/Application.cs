using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Entities.Registration;
using Vnsf.Data.Entities.Shared;

namespace Vnsf.Data.Entities
{
    public class Application : Audit
    {
        public static Application NewApplication(Opportunity opportunity)
        {
            return new Application()
            {
                Id = Guid.NewGuid(),
                Opportunity = opportunity,
                Status = ApplicationStatus.Creating
            };

        }

        public void Submit()
        {
            Status = ApplicationStatus.Submitted;
        }

        public Guid Id { get; set; }
        public ApplicationStatus Status { get; set; } // submitted / withdraw / return / overdue      
        //public bool HasHardcopy { get; set; }

        public virtual Proposal Proposal { get; set; }
        public virtual Award Award { get; set; }
        public virtual Opportunity Opportunity { get; set; }
        public virtual UserAccount Applicant { get; set; }
        public virtual ICollection<ApplicationDocument> Documents { get; set; }


        public Application()
        {
            Documents = new List<ApplicationDocument>();

        }
        public void AddOrUpdateDocument(ApplicationForm form, string name, string description, string contentType, int contentLength, string path)
        {
            var doc = Documents.FirstOrDefault(d => d.Form.Id == form.Id);
            if (doc != null)
            {
                doc.FileName = name;
                doc.Description = description;
                doc.ContentType = contentType;
                doc.ContentLength = contentLength;
                doc.Path = path;
                this.LastUpdated = DateTime.Now;
            }
            else
            {
                Documents.Add(new ApplicationDocument
                {
                    Id = Guid.NewGuid(),
                    FileName = name,
                    Description = description,
                    ContentType = contentType,
                    ContentLength = contentLength,
                    Path = path,
                    CreateDate = DateTime.Now,
                    Form = form
                });
                this.LastUpdated = DateTime.Now;
            }
        }

    }
}
