using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Service.Data.Authorization;

namespace Vnsf.Service.Contract
{
    public interface IAuthorizationService
    {
        IQueryable<ApplicationData> GetAll();
        ApplicationData GetAppById(Guid appId);
        void CreateApplication(ApplicationData item);
        void DeleteApplication(Guid appId);

    }
}
