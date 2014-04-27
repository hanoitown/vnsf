using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataSync.Models;

namespace DataSync.Controllers
{
    public class ProfileController : Controller
    {
        private oms_nsEntities db = new oms_nsEntities();

        //
        // GET: /Profile/

        public ActionResult Index(string name)
        {
            var query = from profile in db.tbl_profile
                        where profile.S_NAME == name 
                        select new ProfileViewModel
                         {
                             Name = profile.S_NAME,
                             Office = profile.S_OFFICE_NAME,
                             Email = profile.S_EMAIL_P,
                             Phone = profile.S_OFFICE_PHONE,
                             Educations = from educations in db.tbl_education 
                                          where educations.S_ID == profile.S_ID 
                                          orderby educations.E_TO descending select educations,
                             Publications = from publications in db.tbl_publication 
                                            where publications.S_ID == profile.S_ID 
                                            orderby publications.P_YEAR descending select publications,
                             Works = from works in db.tbl_work 
                                     where works.S_ID == profile.S_ID 
                                     orderby works.W_TO descending select works
                         };

            return View(query.FirstOrDefault());
        }

    }
}
