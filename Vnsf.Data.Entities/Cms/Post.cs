using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class Post : BaseBusiness
    {
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public int MaxDuration { get; set; }
        public decimal EstimateTotal { get; set; }
        public decimal AwardCeiling { get; set; }
        public decimal AwardFloor { get; set; }
        public DateTime PostDate { get; set; }
        public Guid OpportunityId { get; set; }
        public virtual Opportunity Opportunity { get; set; }
        public virtual ICollection<PostVersion> Versions { get; set; }

        public Post()
            : base()
        {

        }
        public Post(string content, DateTime startDate, DateTime deadline, int maxduration, decimal estimateTotal, decimal awardCeiling, decimal awardFloor)
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

        /// <summary>
        /// FindById announcement by version 
        /// </summary>
        /// <param name="version">null for lastest version</param>
        /// <returns></returns>
        public PostVersion GetAnnouncementVersion(int? version)
        {
            if (version != null)
                return Versions.FirstOrDefault(v => v.Version == version);

            return Versions.OrderByDescending(v => v.Version).FirstOrDefault();
        }

        public void AddAnnoucementVersion(PostVersion version)
        {
            var lastest = GetAnnouncementVersion(null);
            var max = (lastest != null) ? lastest.Version++ : 1;
            version.Version = max;
            Versions.Add(version);
        }
    }
}
