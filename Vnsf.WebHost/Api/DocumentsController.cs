using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;

namespace Vnsf.WebHost.Api
{
    public class DocumentsController : ApiBaseController
    {
        public DocumentsController(IUnitOfWork uow)
            : base(uow)
        {

        }

        public IHttpActionResult ShareLink(string names, string message)
        {
            var emails = names.Split(',');
            var smtpClient = new SmtpClient[emails.Count()];
            for (int i = 0; i < emails.Count(); i++)
            {
                // send mail
                smtpClient[i].SendAsync(new MailMessage(emails[i], emails[i]), null);
            }
            return null;
        }
    }
}
