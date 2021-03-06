﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;

namespace Vnsf.WebHost.Models
{
    public class AnnouncementBindingModel
    {
        public Post Announcement { get; set; }
        public IEnumerable<SelectListItem> Opportunities { get; set; }

        public AnnouncementBindingModel(Post announcement, IEnumerable<Opportunity> opportunities)
        {
            Announcement = announcement;
            Opportunities = opportunities.ToSelectList(o => o.Id.ToString(), o => o.Name, announcement.Id.ToString());
        }
    }
}