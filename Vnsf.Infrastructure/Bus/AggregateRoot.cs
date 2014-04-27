using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vnsf.Infrastructure.Bus
{
    public abstract class AggregateRoot
    {
        private readonly List<IEvent> _events = new List<IEvent>();

        public string Id { get; set; }

        public IEnumerable<IEvent> GetUnPublishedEvents()
        {
            return _events;
        }

        public void MarkEventsPublished()
        {
            _events.Clear();
        }

        protected void ApplyEvent<T>(T @event) where T : IEvent
        {
            _events.Add(@event);
        }
    }
}
