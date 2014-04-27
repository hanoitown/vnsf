using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;

namespace Vnsf.WebHost.Models
{
    public class AnnouncementViewModel
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
        public string Opportunity { get; set; }

        public AnnouncementViewModel()
        {
            
        }
        public AnnouncementViewModel(Announcement a)
        {
            
            Id = a.Id;
            Content = a.Content;
            StartDate = a.StartDate;
            Deadline = a.Deadline;
            MaxDuration = a.MaxDuration;
            EstimateTotal = a.EstimateTotal;
            AwardCeiling = a.AwardCeiling;
            AwardFloor = a.AwardFloor;
            PostDate = a.PostDate;
            Opportunity = (a.Opportunity != null) ? a.Opportunity.Name : string.Empty;
        }
    }
}