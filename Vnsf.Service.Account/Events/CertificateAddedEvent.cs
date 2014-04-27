using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Account;
using Vnsf.Infrastructure.Messanging;

namespace Vnsf.Service.Account.Events
{
    interface IAllowMultiple { }

    public abstract class UserAccountEvent : IEvent
    {
        public UserAccount Account { get; set; }
        public Guid SourceId { get; private set; }
    }

    public class CertificateAddedEvent : UserAccountEvent, IAllowMultiple
    {

        public UserCertificate Certificate { get; set; }
    }
}
