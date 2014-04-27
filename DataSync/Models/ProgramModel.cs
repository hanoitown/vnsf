using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataSync.Models
{
    public class ProgramModel
    {
        public ProgramModel()
        {
            ProgramTypes = new List<tbl_program_type>();
        }
        public IEnumerable<tbl_program_type> ProgramTypes { get; set; }


        
    }
}