using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vnsf.Data.Entities.Account
{
    public class UserCertificate
    {
        public UserCertificate()
        {
        }

        [Key]
        [Column(Order = 1)]
        public virtual Guid UserAccountID { get; internal set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(150)]
        public virtual string Thumbprint { get; internal set; }

        [StringLength(250)]
        public virtual string Subject { get; internal set; }
        
        [ForeignKey("UserAccountID")]
        public virtual UserAccount User { get; internal set; }

    }
}
