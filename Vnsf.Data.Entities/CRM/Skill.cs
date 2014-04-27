using System.Collections.Generic;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities.CRM
{
    public class Skill
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int Level { get; set; }
        public Profile Profile { get; set; }

        public ICollection<SkillLocalized> SkillLocalizeds { get; set; }
    }

    public class SkillLocalized
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public string Name { get; set; }
        public Skill Skill { get; set; }
        public Culture Culture { get; set; }
    }
}