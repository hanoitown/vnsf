namespace Vnsf.Infrastructure.Bus
{
    public interface IMessageBus
    {
        void Publish<T>(T @event) where T : IEvent;

        void PublishAsync<T>(T @event) where T : IEvent;
    }
}