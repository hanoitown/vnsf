
using System;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
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
        IUserAccountRepository UserAccounts { get; }
        IGrantRepository GrantRepo { get; }
        IAnnouncementRepository AnnouncementRepo { get; }
        IClassificationRepository ClassificationRepo { get; }
        IRepository<Grant> Grants { get; }
        IRepository<Opportunity> Opps { get; }
        IRepository<Organization> Organizations { get; }
        IRepository<Category> Categories { get; }
        IRepository<Storage> Storages { get; }
        IRepository<Application> Apps { get; }
        IRepository<ApplicationForm> AppForms { get; }
        IRepository<ApplicationDocument> AppDocuments { get; }
        IDocRepository Documents { get; }

    }
}