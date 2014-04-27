using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Data.Helpers;
using Vnsf.Data.Repository;
using Vnsf.Infrastructure.Repository;

namespace Vnsf.Data.EF
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public VnsfDbContext DbContext { get; set; }

        public ICultureRepository Cultures { get { return GetRepo<ICultureRepository>(); } }
        public IUserAccountRepository UserAccounts { get { return GetRepo<IUserAccountRepository>(); } }
        public IGrantRepository GrantRepo { get { return GetRepo<IGrantRepository>(); } }
        public IOpportunityRepository OpportunitiesRepo { get { return GetRepo<IOpportunityRepository>(); } }
        public IAnnouncementRepository AnnouncementRepo { get { return GetRepo<IAnnouncementRepository>(); } }
        public IClassificationRepository ClassificationRepo { get { return GetRepo<IClassificationRepository>(); } }
        public IRepository<Grant> Grants { get { return GetStandardRepo<Grant>(); } }
        public IRepository<Organization> Organizations { get { return GetStandardRepo<Organization>(); } }
        public IRepository<Category> Categories { get { return GetStandardRepo<Category>(); } }
        public IRepository<Classification> CS { get { return GetStandardRepo<Classification>(); } }
        public IRepository<Storage> Storages { get { return GetStandardRepo<Storage>(); } }
        public IRepository<Doc> Documents { get { return GetStandardRepo<Doc>(); } }
        public UnitOfWork(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Save()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            DbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        protected void CreateDbContext()
        {
            DbContext = new VnsfDbContext();

            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }


        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }

}