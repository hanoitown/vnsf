using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Infrastructure.Repository;

namespace Vnsf.Data.Repository
{
    public interface IAnnouncementRepository : IRepository<Post>
    {
        IQueryable<Post> GetAnnoucmentByGrandId(Guid grantId);
        IQueryable<Post> GetAvailableAnnouncement();

        Post GetAnnouncementsById(Guid id);
    }
}
