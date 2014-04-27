using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Vnsf.Infrastructure.Repository
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T item);

    }
}
