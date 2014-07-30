using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Entities.Principle;
using Vnsf.Data.Entities.Shared;

namespace Vnsf.Data.Entities
{
    public class UserProfile
    {
        public static UserProfile New(string nameFirst, string nameLast, DateTime? birthday, bool gender, UserAccount account)
        {
            return new UserProfile()
            {
                Id = Guid.NewGuid(),
                Name = new FullName(nameFirst, nameLast),
                BirthDay = birthday,
                Gender = gender,
                Account = account
            };
        }

        public Guid Id { get; set; }
        public UserTitle ScienceTitle { get; set; }
        public FullName Name { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool Gender { get; set; }

        public string ResearchDirection { get; set; }
        public string IdNo { get; set; }
        public string IdIssuer { get; set; }
        public IdKind IdKind { get; set; }
        public DateTime IssueDate { get; set; }

        public virtual Category Fields { set; get; }
        public virtual Job Working { set; get; }
        public virtual BankAccount BankAccount { get; set; }
        public virtual Avatar Avatar { get; set; }
        public virtual UserAccount Account { get; set; }
        public virtual Contact Contact { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
        public virtual ICollection<Job> WorkExperiences { get; set; }
        public virtual ICollection<Project> Projects { set; get; }
        public UserProfile()
        {
            Educations = new List<Education>();
            Publications = new List<Publication>();
            WorkExperiences = new List<Job>();
            Projects = new List<Project>();
        }


        public void AddEducation(string specialization, string program, string university, int duration, MonthYear startdate, MonthYear enddate)
        {
            Educations.Add(Education.Create(specialization, program, university, duration, startdate, enddate));

        }

        public void AddUserPublication(string issn, string title, string brief, string authors, string publisher, DateTime publishDate)
        {
            Publications.Add(Publication.New(issn, title, brief, authors, publisher, publishDate));
        }

        public void AddWorkExperience(string position, string quitReason, string company, DateTime fromdate, DateTime? todate)
        {
            WorkExperiences.Add(Job.New(position, quitReason, company, fromdate, todate));
        }

        public void AddProject(string name, string description, string role, long totalbudget, int duration, string othercompany)
        {
            Projects.Add(Project.New(name, description, role, totalbudget, duration, othercompany));
        }
    }

    public class FullName : ValueObject<FullName>
    {
        public string First { get; set; }
        public string Last { get; set; }

        public FullName()
        {

        }
        public FullName(string firstname, string lastname)
        {
            First = firstname;
            Last = lastname;
        }
    }

    public enum IdKind
    {
        NationalID,
        Passport
    }

}
