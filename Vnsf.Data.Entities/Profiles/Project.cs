using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities.Principle
{
    public class Project
    {
        public static Project New(string name, string description, string role, long totalbudget, int duration, string othercompany)
        {
            return new Project()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Role = role,
                TotalBudget = totalbudget,
                Duration = duration,
                OtherCompany = othercompany
            };
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
        public long TotalBudget { get; set; }
        public int Duration { get; set; }
        public string OtherCompany { get; set; }
        public virtual Organization Company { get; set; }
        public virtual UserProfile Profile { get; set; }

    }
}
