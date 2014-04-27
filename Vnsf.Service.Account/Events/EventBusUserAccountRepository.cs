using Vnsf.Data.Entities.Account;
using Vnsf.Data.Repository;
using Vnsf.Infrastructure.Messanging;
using Vnsf.Infrastructure.Repository;

namespace Vnsf.Service.Account.Events
{
    public class EventBusUserAccountRepository :
       EventBusRepository<UserAccount>, IUserAccountRepository
    {
        public EventBusUserAccountRepository(IUserAccountRepository inner, IEventBus validationBus, IEventBus eventBus)
            : base(inner, validationBus, eventBus)
        {
        }
    }
}
