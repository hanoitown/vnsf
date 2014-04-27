using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Vnsf.Infrastructure.Repository
{
    public interface IReadOnlyRepository<T> where T : class
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includingProperties);
        IQueryable<T> FilterBy(Expression<Func<T, bool>> predicate);
        T FindBy(Expression<Func<T, bool>> predicate);
        T FindById(params object[] keys);

        Task<T> FindAsyncBy(Expression<Func<T, bool>> predicate);
        Task<T> FindAsyncById(params object[] keys);

    }
}