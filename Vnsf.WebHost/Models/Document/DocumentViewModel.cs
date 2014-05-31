using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vnsf.Data.Entities;
using Vnsf.WebHost.Infrastructure.Mapping;

namespace Vnsf.WebHost.Models.Document
{
    public class DocumentViewModel : IHaveCustomMapping
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public bool Selected { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public string Kind { get; set; }
        public int ContentLength { get; set; }
        public bool IsFolder { get; set; }
        public string Path { get; set; }
        public string Location { get; set; }

        public void CreateMapping(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Doc, DocumentViewModel>()
                .ForMember(d => d.Kind, opt => opt.ResolveUsing<ContentTypeResolver>())
                .ForMember(d => d.Selected, opt => opt.Ignore());

        }
    }

    public class ContentTypeResolver : ValueResolver<Doc, string>
    {
        protected override string ResolveCore(Doc source)
        {
            switch (source.ContentType)
            {
                case "image/png":
                case "image/jpg":
                    return "image";
                case "application/msword":
                    return "document";
                case "application/x-zip-compressed":
                    return "compressed";
                default:
                    return "file";
            }
        }
    }

}