using System;

namespace Vnsf.Infrastructure.Messanging
{
    public interface IEvent
    {
        Guid SourceId { get; }
    }
}
