using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Infrastructure.EventSourcing;
using Vnsf.Infrastructure.Messanging;

namespace Vnsf.Infrastructure.Repository
{
    public class EventBusRepository<T> : IRepository<T>
        where T : class, IEventSource
    {
        
        readonly IRepository<T> _inner;
        readonly IEventBus _validationBus;
        readonly IEventBus _eventBus;

        protected EventBusRepository(IRepository<T> inner, IEventBus validationBus, IEventBus eventBus)
        {
            if (inner == null) throw new ArgumentNullException("inner");
            if (validationBus == null) throw new ArgumentNullException("validationBus");
            if (eventBus == null) throw new ArgumentNullException("eventBus");

            this._inner = inner;
            this._validationBus = validationBus;
            this._eventBus = eventBus;
        }

        private void RaiseValidation(IEventSource source)
        {
            if (source == null) throw new ArgumentNullException("source");
            foreach (var evt in source.GetEvents())
            {
                this._validationBus.RaiseEvent(evt);
            }
        }

        private void RaiseEvents(IEventSource source)
        {
            if (source == null) throw new ArgumentNullException("source");
            foreach (var evt in source.GetEvents())
            {
                this._eventBus.RaiseEvent(evt);
            }

            source.Clear();
        }

        public IQueryable<T> GetAll()
        {
            return _inner.GetAll();
        }

        public T Get(params object[] keys)
        {
            return _inner.Get(keys);
        }

        public T Create()
        {
            return _inner.Create();
        }

        public void Add(T item)
        {
            RaiseValidation(item);
            _inner.Add(item);
            RaiseEvents(item);
        }

        public void Remove(T item)
        {
            RaiseValidation(item);
            _inner.Remove(item);
            RaiseEvents(item);
        }

        public void Update(T item)
        {
            RaiseValidation(item);
            _inner.Update(item);
            RaiseEvents(item);
        }

    }
}
