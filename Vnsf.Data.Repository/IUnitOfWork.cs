
using System;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Data.Entities.Globalization;
using Vnsf.Data.Entities.Registration;
using Vnsf.Infrastructure.Repository;

namespace Vnsf.Data.Repository
{
    /// <summary>
    /// Interface for the "Unit of Work"
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task<int> SaveAsync();

        ICultureRepository Cultures { get; }
        IRepository<LocalizedCulture> LocalCultures { get; }
        IUserAccountRepository UserAccounts { get; }
        IGrantRepository GrantRepo { get; }
        IClassificationRepository ClassificationRepo { get; }
        IRepository<Classification> Classifications { get; }
        IRepository<Grant> Grants { get; }
        IRepository<Opportunity> Opps { get; }
        IRepository<Organization> Organizations { get; }
        IRepository<Category> Categories { get; }
        IRepository<Storage> Storages { get; }
        IRepository<Application> Apps { get; }
        IRepository<ApplicationForm> AppForms { get; }
        IRepository<ApplicationDocument> AppDocuments { get; }
        IDocRepository Documents { get; }
        IRepository<UserProfile> Profiles { get; }
        IRepository<Report> Reports { get; }
        IRepository<Proposal> Proposals { get; }

    }
}