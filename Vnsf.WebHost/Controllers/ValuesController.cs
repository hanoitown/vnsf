using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Vnsf.Data.Entities;
using Vnsf.Data.Repository;
using Vnsf.WebHost.Base;

namespace Vnsf.WebHost.Controllers
{
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path)
            : base(path)
        { }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
            return name.Replace("\"", string.Empty); //this is here because Chrome submits files in quotation marks which get treated as part of the filename and get escaped
        }
    }

    public class FileHttpResponseMessage : HttpResponseMessage
    {
        private string filePath;
        public FileHttpResponseMessage(string filePath)
        { this.filePath = filePath; }
        protected override void Dispose(bool disposing)
        { base.Dispose(disposing); Content.Dispose(); File.Delete(filePath); }
    }

    public class CustomStreamContent : StreamContent
    {
        string filePath;

        public CustomStreamContent(string filePath)
            : this(File.OpenRead(filePath))
        {
            this.filePath = filePath;
        }

        private CustomStreamContent(Stream fileStream)
            : base(content: fileStream)
        {
        }

        protected override void Dispose(bool disposing)
        {
            //close the file stream
            base.Dispose(disposing);

            try
            {
                File.Delete(this.filePath);
            }
            catch (Exception ex)
            {
                //log this exception somewhere so that you know something bad happened
            }
        }
    }
    public class FileDesc
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }

        public FileDesc()
        {

        }
        public FileDesc(string n, string p, long s)
        {
            Name = n;
            Path = p;
            Size = s;
        }
    }
    public class ValuesController : ApiBaseController
    {
        private IUnitOfWork _unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET api/values
        public IEnumerable<Grant> Get()
        {
            return _unitOfWork.Grants.All.ToArray();
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Stream file = new MemoryStream();
                var result = new FileStream("C:\\Users\\Nguyen\\Desktop\\ProMVC5.pdf", FileMode.Open, FileAccess.Read);
                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                result.Position = 0;
                HttpResponseMessage response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StreamContent(result);
                response.Content.Headers.Add("Content-Disposition", "attachment; filename=" + "foo.txt");
                return response;
            }
            catch (IOException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        // POST api/values
        public Task<IEnumerable<FileDesc>> Post(string folderName)
        {
            folderName = "uploads";
            var PATH = HttpContext.Current.Server.MapPath("~/" + folderName);
            var rootUrl = Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.AbsolutePath, String.Empty);
            if (Request.Content.IsMimeMultipartContent())
            {
                var streamProvider = new CustomMultipartFormDataStreamProvider(PATH);
                var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith<IEnumerable<FileDesc>>(t =>
                {

                    if (t.IsFaulted || t.IsCanceled)
                    {
                        throw new HttpResponseException(HttpStatusCode.InternalServerError);
                    }

                    var fileInfo = streamProvider.FileData.Select(i =>
                    {
                        var info = new FileInfo(i.LocalFileName);
                        return new FileDesc(info.Name, rootUrl + "/" + folderName + "/" + info.Name, info.Length / 1024);
                    });
                    return fileInfo;
                });

                return task;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
