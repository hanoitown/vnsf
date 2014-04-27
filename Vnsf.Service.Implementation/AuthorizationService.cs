using System.Linq;
using Vnsf.Data.Entities.Authorization;
using Vnsf.Data.Repository;
using Vnsf.Service.Contract;
using Vnsf.Service.Data.Authorization;

namespace Vnsf.Service.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        public IUnitOfWork Uow { get; set; }

        public AuthorizationService(IUnitOfWork uow)
        {
            Uow = uow;
        }

        public IQueryable<ApplicationData> GetAll()
        {
            return Uow.Applications.GetAll().Select(a => new ApplicationData
                                                            {
                                                                Id = a.Id,
                                                                Name = a.Name,
                                                                DisplayName = a.DisplayName,
                                                                Description = a.Description
                                                            });
        }

        public Data.Authorization.ApplicationData GetAppById(System.Guid appId)
        {
            throw new System.NotImplementedException();
        }

        public void CreateApplication(ApplicationData item)
        {
            Uow.Applications.Add(new Application
                                     {
                                         Id = item.Id,
                                         Name = item.Name,
                                         DisplayName = item.DisplayName,
                                         Description = item.Description
                                     });
        }

        public void DeleteApplication(System.Guid appId)
        {
            throw new System.NotImplementedException();
        }
    }
}
