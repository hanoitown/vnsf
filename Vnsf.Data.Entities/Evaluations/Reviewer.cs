using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Shared;

namespace Vnsf.Data.Entities.Evaluations
{
    public class Reviewer : Audit
    {
        public Guid Id { get; set; }
        public ReviewerGroup Group { get; set; }
        public UserProfile Profile { get; set; }
        public ICollection<Category> Fields { get; set; }
    }

    public enum ReviewerGroup
    {
        Standard,               // elect by SPO
        PersonalRecommend,      // propose by individual
        BoardRecommend          // elect by science board
    }
}
