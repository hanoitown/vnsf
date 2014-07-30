using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities.Principle;

namespace Vnsf.Data.Entities
{
    public class Job
    {
        public static Job New(string position, string quitReason, string company, DateTime fromdate, DateTime? todate)
        {
            return new Job()
            {
                Id = Guid.NewGuid(),
                Position = position,
                QuitReseason = quitReason,
                Company = company,
                FromDate = fromdate,
                ToDate = todate
            };
        }

        public Guid Id { set; get; }
        public UserTitle JobTitle { get; set; }        
        public string QuitReseason { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public string Position { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual UserProfile Profile { get; set; }
    }
}
