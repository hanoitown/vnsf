using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Extensions;
using Vnsf.Data.Repository;
using Vnsf.Infrastructure.Repository;

namespace Vnsf.Data.EF
{
    /// <summary>
    /// The EF-dependent, generic repository for data access
    /// </summary>
    /// <typeparam name="T">Type of entity for this Repository.</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        protected DbContext DbContext { get; set; }

        public DbSet<T> DbSet { get; set; }

        #region synchronous
        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetById(object id)
        {
            //return DbSet.FirstOrDefault(PredicateBuilder.GetByIdPredicate<T>(id));
            return DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual T FindById(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public void Remove(T item)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(item);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(item);
                DbSet.Remove(item);
            }
        }

        public IQueryable<T> All
        {
            get { return this.DbSet; }
        }

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public T FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Find(predicate);
        }


        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includingProperties)
        {
            IQueryable<T> query = DbSet;
            foreach (var includingProperty in includingProperties)
            {
                query = query.Include(includingProperty);
            }
            return query;
        }

        #endregion synchronous

        #region async implementation

        public async Task<T> FindAsyncBy(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.FindAsync(predicate);
        }

        public async Task<T> FindAsyncById(params object[] keys)
        {
            return await DbSet.FindAsync(keys);
        }

        #endregion
    }
}
