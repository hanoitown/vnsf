using System;
using System.Collections.Generic;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities.CRM
{
    public class ProjectEvolment
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int ProjectId { get; set; }
        public DateTime Start { get; set; }
        public TimeSpan Duration { get; set; }

        public Organization Owner { get; set; }
        public Organization Funding { get; set; }
        public Position Position { get; set; }
        public Profile Profile { get; set; }

        public ICollection<ProjectEvolmentLocalized> ProjectEvolmentLocalizeds { get; set; }
        
    }

    public class ProjectEvolmentLocalized
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectEvolment ProjectEvolment { get; set; }
        public Culture Culture { get; set; }
    }

}