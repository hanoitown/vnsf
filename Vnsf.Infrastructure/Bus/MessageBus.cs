using System.Linq;
using System.Threading.Tasks;
using NLog;
using ReflectionMagic;
using Microsoft.Practices.ServiceLocation;
using Vnsf.Infrastructure.Extensions;

namespace Vnsf.Infrastructure.Bus
{
    public class MessageBus : IMessageBus
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        private readonly IServiceLocator _serviceLocator;

        public MessageBus(
            IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public void Publish<T>(T @event) where T : IEvent
        {
            var type = typeof(IEventHandler<>).MakeGenericType(@event.GetType());
            
            var handlers = ServiceLocator.Current.GetAllInstances(type);

            foreach (var handler in handlers)
            {
                log.Debug("Publishing Event: {0}", @event.GetType());
                handler.AsDynamic().Handle(@event);
            }
        }

        public void PublishAsync<T>(T @event) where T : IEvent
        {
            var type = typeof(IEventHandler<>).MakeGenericType(@event.GetType());

            var handlers = ServiceLocator.Current.GetAllInstances(type);

            foreach (var handler in handlers)
            {
                var asyncHandler = handler;

                log.Debug("Publishing Async Event: {0}", @event.GetType().Name);
                
                if(@event.IsLongRunning)
                {
                    Task.Factory.StartNew(state => asyncHandler.AsDynamic().Handle(@event), @event.GetType().Name, TaskCreationOptions.LongRunning).LogExceptions();                    
                }
                else
                {
                    Task.Factory.StartNew(state => asyncHandler.AsDynamic().Handle(@event), @event.GetType().Name).LogExceptions();
                }
            }
        }
    }
}