using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Globalization;
using Vnsf.Infrastructure.Repository;

namespace Vnsf.Data.Repository
{
    public interface ICultureRepository : IRepository<Culture>
    {
        IEnumerable<Culture> GetCultures();
    }
}
