using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities;
using Vnsf.Data.Repository;

namespace Vnsf.Data.EF
{
    public class AnnouncementRepository : Repository<Post>, IAnnouncementRepository
    {
        public AnnouncementRepository(DbContext context) : base(context) { }


        public IQueryable<Post> GetAnnoucmentByGrandId(Guid grantId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Post> GetAvailableAnnouncement()
        {
            return this.DbSet.Include(a => a.Opportunity);
        }


        public Post GetAnnouncementsById(Guid id)
        {
            return this.DbSet.Include(a => a.Opportunity).FirstOrDefault(a => a.Id == id);
        }
    }
}
