using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Models.Document
{
    public class SelectDocumentBindingModel : IHaveCustomMapping
    {
        public bool Selected { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
        public bool IsFolder { get; set; }
        public string Path { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? Created { get; set; }
        public void CreateMapping(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Doc, SelectDocumentBindingModel>()
                .ForMember(d => d.Selected, opt => opt.Ignore());

        }
    }
}