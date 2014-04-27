using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Infrastructure.Messanging;

namespace Vnsf.Infrastructure.EventSourcing
{
    public class EventBus : List<IEventHandler>, IEventBus
    {
        readonly Dictionary<Type, IEnumerable<IEventHandler>> _handlerCache = new Dictionary<Type, IEnumerable<IEventHandler>>();
        readonly GenericMethodActionBuilder<IEventHandler, IEvent> _actions = new GenericMethodActionBuilder<IEventHandler, IEvent>(typeof(IEventHandler<>), "Handle");

        public void RaiseEvent(IEvent evt)
        {
            var action = GetAction(evt);
            var matchingHandlers = GetHandlers(evt);
            foreach (var handler in matchingHandlers)
            {
                action(handler, evt);
            }
        }

        Action<IEventHandler, IEvent> GetAction(IEvent evt)
        {
            return _actions.GetAction(evt);
        }

        private IEnumerable<IEventHandler> GetHandlers(IEvent evt)
        {
            var eventType = evt.GetType();
            if (!_handlerCache.ContainsKey(eventType))
            {
                var eventHandlerType = typeof(IEventHandler<>).MakeGenericType(eventType);
                var query =
                    from handler in this
                    where eventHandlerType.IsInstanceOfType(handler)
                    select handler;
                var handlers = query.ToArray().Cast<IEventHandler>();
                _handlerCache.Add(eventType, handlers);
            }
            return _handlerCache[eventType];
        }
    }

    public class AggregateEventBus : List<IEventBus>, IEventBus
    {
        public void RaiseEvent(IEvent evt)
        {
            foreach (var eb in this)
            {
                eb.RaiseEvent(evt);
            }
        }
    }
}
