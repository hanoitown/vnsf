using System;
using System.Collections.Generic;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities.CRM
{
    public class Job
    {
        public int Id { get; set; }
        public Organization Organization { get; set; }
        public DateTime Start { get; set; }
        public DateTime Leave { get; set; }

        public ICollection<JobLocalized> JobLocalizeds { get; set; }
    }

    public class JobLocalized
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Job Job { get; set; }
        public Culture Culture { get; set; }
    }
}