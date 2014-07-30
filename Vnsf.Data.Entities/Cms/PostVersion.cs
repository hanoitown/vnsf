using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities.Shared;

namespace Vnsf.Data.Entities
{
    public class PostVersion : ValueObject<PostVersion>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TitleShort { get; set; }
        public string Content { get; set; }

        public int Version { get; set; }
        internal PostVersion()
        {

        }
    }
}
