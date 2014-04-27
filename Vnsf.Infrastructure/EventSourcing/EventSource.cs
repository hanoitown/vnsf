using System;
using System.Collections.Generic;
using Vnsf.Infrastructure.Messanging;

namespace Vnsf.Infrastructure.EventSourcing
{
    /// <summary>
    /// Base class for event sourced entities that implements <see cref="IEventSource"/>. 
    /// </summary>
    /// <remarks>
    /// <see cref="IEventSource"/> entities do not require the use of <see cref="EventSource"/>, but this class contains some common 
    /// useful functionality related to versions and rehydration from past events.
    /// </remarks>
    public abstract class EventSource 
    {
        private readonly Dictionary<Type, Action<IVersionedEvent>> handlers = new Dictionary<Type, Action<IVersionedEvent>>();
        private readonly List<IVersionedEvent> pendingEvents = new List<IVersionedEvent>();

        private readonly Guid _id;
        private int version = -1;

        protected EventSource(Guid id)
        {
            this._id = id;
        }

        public Guid Id
        {
            get { return this._id; }
        }

        /// <summary>
        /// Gets the entity's version. As the entity is being updated and events being generated, the version is incremented.
        /// </summary>
        public int Version
        {
            get { return this.version; }
            protected set { this.version = value; }
        }

        /// <summary>
        /// Gets the collection of new events since the entity was loaded, as a consequence of command handling.
        /// </summary>
        public IEnumerable<IVersionedEvent> Events
        {
            get { return this.pendingEvents; }
        }

        /// <summary>
        /// Configures a handler for an event. 
        /// </summary>
        protected void Handles<TEvent>(Action<TEvent> handler)
            where TEvent : IEvent
        {
            this.handlers.Add(typeof(TEvent), @event => handler((TEvent)@event));
        }

        protected void LoadFrom(IEnumerable<IVersionedEvent> pastEvents)
        {
            foreach (var e in pastEvents)
            {
                this.handlers[e.GetType()].Invoke(e);
                this.version = e.Version;
            }
        }

        protected void Update(VersionedEvent e)
        {
            e.SourceId = this.Id;
            e.Version = this.version + 1;
            this.handlers[e.GetType()].Invoke(e);
            this.version = e.Version;
            this.pendingEvents.Add(e);
        }
    }
}