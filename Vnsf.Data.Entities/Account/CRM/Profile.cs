using System.Collections.Generic;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities.CRM
{
    public class Profile
    {
        public int Id { get; set; }
        
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Mobile { get; set; }
        public string OfficePhone { get; set; }
        public string HomePhone { get; set; }
        public Attached Avatar { get; set; }

        public int ScienceTitleId { get; set; }
        public NameTitle ScienceTitle { get; set; }
        public int AdminTitleId { get; set; }
        public NameTitle AdminTitle { get; set; }
        public Organization Office { get; set; }
        public Organization Home { get; set; }

        public ICollection<Field> Experts { get; set; }
        public ICollection<Field> Fields { get; set; }
        public ICollection<IdCard> IdCards { get; set; }
        public ICollection<Publication> Publications { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public ICollection<Certification> Certifications { get; set; }
        public ICollection<ProjectEvolment> Evolments { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<BankAccount> BackAccounts { get; set; }

        public ICollection<ProfileLocalized> ProfileLocalizeds { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2,
        NotSpecified = 3
    }

    public class ProfileLocalized
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }

        public Profile Profile { get; set; }
        public Culture Culture { get; set; }

    }
}
