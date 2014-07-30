using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Globalization;
using Vnsf.Data.Entities.Registration;
using Vnsf.Data.Helpers;
using Vnsf.Data.Repository;
using Vnsf.Infrastructure.Repository;

namespace Vnsf.Data.EF
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public VnsfDbContext DbContext { get; set; }

        public ICultureRepository Cultures { get { return GetRepo<ICultureRepository>(); } }
        public IRepository<LocalizedCulture> LocalCultures { get { return GetStandardRepo<LocalizedCulture>(); } }
        public IUserAccountRepository UserAccounts { get { return GetRepo<IUserAccountRepository>(); } }
        public IGrantRepository GrantRepo { get { return GetRepo<IGrantRepository>(); } }
        public IClassificationRepository ClassificationRepo { get { return GetRepo<IClassificationRepository>(); } }
        public IRepository<Classification> Classifications { get { return GetStandardRepo<Classification>(); } }
        public IRepository<Grant> Grants { get { return GetStandardRepo<Grant>(); } }
        public IRepository<Opportunity> Opps { get { return GetStandardRepo<Opportunity>(); } }
        public IRepository<Organization> Organizations { get { return GetStandardRepo<Organization>(); } }
        public IRepository<Category> Categories { get { return GetStandardRepo<Category>(); } }
        public IRepository<Classification> CS { get { return GetStandardRepo<Classification>(); } }
        public IRepository<Storage> Storages { get { return GetStandardRepo<Storage>(); } }
        public IRepository<Application> Apps { get { return GetStandardRepo<Application>(); } }
        public IRepository<ApplicationForm> AppForms { get { return GetStandardRepo<ApplicationForm>(); } }
        public IRepository<ApplicationDocument> AppDocuments { get { return GetStandardRepo<ApplicationDocument>(); } }
        public IDocRepository Documents { get { return GetRepo<IDocRepository>(); } }
        public IRepository<Report> Reports { get { return GetStandardRepo<Report>(); } }
        public IRepository<UserProfile> Profiles { get { return GetStandardRepo<UserProfile>(); } }
        public IRepository<Proposal> Proposals { get { return GetStandardRepo<Proposal>(); } }

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
            foreach (var change in DbContext.ChangeTracker.Entries().Where(x => x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified))
            {
                var audited = change.Entity as IAudit;
                if (audited != null)
                {
                    if (change.State == System.Data.Entity.EntityState.Added)
                    {
                        audited.Created = DateTime.Now;
                    }
                    audited.LastUpdated = DateTime.Now;
                }
            }
            DbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            foreach (var change in DbContext.ChangeTracker.Entries().Where(x => x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified))
            {
                var audited = change.Entity as IAudit;
                if (audited != null)
                {
                    if (change.State == System.Data.Entity.EntityState.Added)
                    {
                        audited.Created = DateTime.Now;
                    }
                    audited.LastUpdated = DateTime.Now;
                }
            }
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