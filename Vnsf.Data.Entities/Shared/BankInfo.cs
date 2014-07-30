using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Data.Entities.Shared
{
    public class BankInfo
    {
        public static BankInfo New(string shortname, string fullname)
        {
            return new BankInfo
            {
                Id = Guid.NewGuid(),
                ShortName = shortname,
                Fullname = fullname
            };
        }
        public Guid Id { get; set; }
        public string ShortName { get; set; }
        public string Fullname { get; set; }
    }    
}
