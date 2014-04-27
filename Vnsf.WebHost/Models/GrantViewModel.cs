using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Models
{
    public class GrantViewModel : IMapFrom<Grant>
    {
        public Guid Id { set; get; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Objective { get; set; }
        public int MaxDuration { get; set; }
        public double Total { set; get; }
        public int MaxAward { set; get; }
        public string ClassificationSystemName { set; get; }
        public string AgencyName { get; set; }
        public DateTime? LastUpdated { set; get; }
        public List<OpportunityViewModel> Opportunities { get; set; }
        public GrantViewModel()
        {

        }
        public GrantViewModel(Grant g)
        {
            Id = g.Id;
            Code = g.Code;
            Name = g.Name;
            Description = g.Description;
            Objective = g.Objective;
            MaxAward = g.MaxAward;
            MaxDuration = g.MaxDuration;
            Total = g.Total;
            AgencyName = g.Agency != null ? g.Agency.Name : string.Empty;
            Opportunities = new List<OpportunityViewModel>(g.Opportunities.Select(o => new OpportunityViewModel(o)));
            LastUpdated = g.LastUpdated;
        }

        public void CreateMapping(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Grant, GrantViewModel>()
                .ForMember(g => g.AgencyName, opt => opt.MapFrom(d => d.Agency.Name));
        }
    }
}