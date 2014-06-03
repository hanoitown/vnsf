
using System;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
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
        IOpportunityRepository OpportunitiesRepo { get; }
        IAnnouncementRepository AnnouncementRepo { get; }
        IClassificationRepository ClassificationRepo { get; }
        IRepository<Grant> Grants { get; }
        IRepository<Organization> Organizations { get; }
        IRepository<Category> Categories { get; }
        IRepository<Storage> Storages { get; }
        IRepository<ApplicationItem> AppItems { get; }
        IDocRepository Documents { get; }

    }
}