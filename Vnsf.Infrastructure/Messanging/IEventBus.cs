using System.Collections.Generic;

namespace Vnsf.Infrastructure.Messanging
{
    public interface IEventBus
    {
        void RaiseEvent(IEvent evt);
    }
}
