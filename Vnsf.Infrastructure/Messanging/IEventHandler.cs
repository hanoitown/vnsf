using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Infrastructure.Messanging
{
    public interface IEventHandler { }
    public interface IEventHandler<in T> : IEventHandler
        where T : IEvent
    {
        void Handle(T evt);
    }

    public class DelegateEventHandler<T> : IEventHandler<T>
        where T : IEvent
    {
        readonly Action<T> _action;
        public DelegateEventHandler(Action<T> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            this._action = action;
        }

        public void Handle(T evt)
        {
            _action(evt);
        }
    }
}
