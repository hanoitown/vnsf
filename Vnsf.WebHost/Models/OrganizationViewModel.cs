﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;

namespace Vnsf.WebHost.Models
{
    public class OrganizationViewModel
    {
        public Guid Id { set; get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}