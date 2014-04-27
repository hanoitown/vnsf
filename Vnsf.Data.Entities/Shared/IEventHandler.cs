namespace Vnsf.Data.Entities.Shared
{
   /// <summary>
   /// Handles events of class <typeparamref name="TEvent"/> emitted by <typeparamref name="TAggregate"/>
   /// </summary>
   /// <typeparam name="TAggregate">Aggregate which emitts this event..</typeparam>
   /// <typeparam name="TEvent">Event type.</typeparam>
   public interface IEventHandler<TAggregate, TEvent>
      where TAggregate : AggregateRoot
      where TEvent : IEvent
   {
      /// <summary>
      /// Handles the event.
      /// </summary>
      /// <param name="source">Event source.</param>
      /// <param name="event">Event object.</param>
      void Handle(TAggregate source, TEvent @event);
   }
}