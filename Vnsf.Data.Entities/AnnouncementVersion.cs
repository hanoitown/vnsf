using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities.Shared;

namespace Vnsf.Data.Entities
{
    public class AnnouncementVersion : ValueObject<AnnouncementVersion>
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public int MaxDuration { get; set; }
        public decimal EstimateTotal { get; set; }
        public decimal AwardCeiling { get; set; }
        public decimal AwardFloor { get; set; }
        public DateTime PostDate { get; set; }
        public int Version { get; set; }
        public Guid AnnouncementId { get; set; }
        public virtual Announcement Announcement { get; set; }
        internal AnnouncementVersion()
        {

        }

        public AnnouncementVersion(string content, DateTime startDate, DateTime deadline, int maxduration, decimal estimateTotal, decimal awardCeiling, decimal awardFloor)
        {
            Content = content;
            StartDate = startDate;
            Deadline = deadline;
            MaxDuration = maxduration;
            EstimateTotal = estimateTotal;
            AwardCeiling = awardCeiling;
            AwardFloor = awardFloor;
            PostDate = DateTime.UtcNow;
        }

        public AnnouncementVersion(AnnouncementVersion a)
            : this(a.Content, a.StartDate, a.Deadline, a.MaxDuration, a.EstimateTotal, a.AwardCeiling, a.AwardFloor)
        {

        }
    }
}
