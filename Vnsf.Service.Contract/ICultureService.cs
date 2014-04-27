using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Globalization;

namespace Vnsf.Service.Contract
{
    public interface ICultureService
    {
        Culture GetById(Guid Id);
        IEnumerable<Culture> GetCulture();
        void AddLanguage(Guid id,Language item);
        
    }
}
