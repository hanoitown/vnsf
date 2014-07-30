using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vnsf.WebHost.Models.ISO
{
    public class PublishFeeApplicationBindingModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Working { get; set; }
        public EgibilityGroup Group { get; set; }
        public List<string> Publications { get; set; }
        public List<string> Documents { get; set; }
    }
}