using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vnsf.Data.Entities.Account;
using Vnsf.Data.Entities.Document;
using Vnsf.Data.Entities.Registration;

namespace Vnsf.Data.Entities
{
    public class ApplicationDocument : FileBase
    {
        public static ApplicationDocument NewDocument(Application app, ApplicationForm form, string name, string description, string contentType, int contentLength, string path)
        {
            return new ApplicationDocument()
            {
                Id = Guid.NewGuid(),
                FileName = name,
                Description = description,
                ContentType = contentType,
                ContentLength = contentLength,
                Path = path,
                CreateDate =DateTime.Now,
                Form = form,
                Application = app
            };
        }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ApplicationForm Form { get; set; }
        public virtual Application Application { get; set; }
    }
}
