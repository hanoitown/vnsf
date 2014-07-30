using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities.Cms
{
    public class PostLocalized
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TitleShort { get; set; }
        public string Content { get; set; }
        public Culture Culture { get; set; }
    }
}
