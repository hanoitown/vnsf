using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vnsf.WebHost.Models.Document
{
    public class FileUploadResultModel
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
        public string Thumbnail_url { get; set; }

    }
}