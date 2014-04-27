
using Vnsf.Infrastructure.Validations;
namespace Vnsf.Infrastructure.Bus
{
    public abstract class Event : IEvent
    {
        protected Event(
            AggregateRoot sender,
            bool isLongRunning = false)
        {
            Requires.IsNotNull(sender, "sender");
            
            Sender = sender;
            IsLongRunning = isLongRunning;
        }

        public AggregateRoot Sender { get; private set; }

        public bool IsLongRunning { get; private set; }
    }
}