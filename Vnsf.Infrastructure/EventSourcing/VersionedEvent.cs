using System;

namespace Vnsf.Infrastructure.EventSourcing
{
    public abstract class VersionedEvent : IVersionedEvent
    {
        public Guid SourceId { get; set; }

        public int Version { get; set; }
    }
}