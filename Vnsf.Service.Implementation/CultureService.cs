using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Data.Entities.Globalization;
using Vnsf.Data.Repository;
using Vnsf.Service.Contract;

namespace Vnsf.Service.Implementation
{
    public class CultureService : ICultureService
    {
        IUnitOfWork _uow;

        public CultureService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //public Culture GetById(Guid Id)
        //{
        //    return _uow.Cultures.GetById(Id);
        //}

        //public IEnumerable<Culture> GetCulture()
        //{
        //    return _uow.Cultures.GetAll();
        //}

        //public void AddLanguage(Guid id, Language lang)
        //{
        //    var item = GetById(id);
        //    if (item == null)
        //        throw new NullReferenceException("");
        //    item.LanguageAssoication(lang, lang.Iso2);
        //    _uow.Commit();
        //}
    }
}
