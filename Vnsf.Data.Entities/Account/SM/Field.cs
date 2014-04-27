using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Data.Entities
{
    public class Field
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public FieldType FieldType { get; set; }
        public int? ParentId { get; set; }
        public Field Parent { set; get; }

    }

    public enum FieldType
    {
        Industry = 1,
        Major = 2,
        Specialization = 3,
        Other = 4

    }

    public class FieldLocalization
    {
        public int IndustryId { get; set; }
        public int CultureId { get; set; }
        public string Name { get; set; }
        public Field Industry { get; set; }
        public Culture Culture { get; set; }
    }

}
