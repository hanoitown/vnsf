using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace Vnsf.WebHost.Api
{
    public class UploadController : ApiController
    {
        // Enable both Get and Post so that our jquery call can send data, and get a status
        //[HttpGet]
        //[HttpPost]
        //public HttpResponseMessage Upload2()
        //{
        //    // Get a reference to the file that our jQuery sent.  Even with multiple files, they will all be their own request and be the 0 index
        //    HttpPostedFile file = HttpContext.Current.Request.Files[0];

        //    // do something with the file in this space 
        //    // {....}
        //    // end of file doing

        //    // Now we need to wire up a response so that the calling script understands what happened
        //    HttpContext.Current.Response.ContentType = "text/plain";
        //    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    var result = new { name = file.FileName };

        //    HttpContext.Current.Response.Write(serializer.Serialize(result));
        //    HttpContext.Current.Response.StatusCode = 200;

        //    // For compatibility with IE's "done" event we need to return a result as well as setting the context.response
        //    return new HttpResponseMessage(HttpStatusCode.OK);

        //}

        [HttpGet]
        [HttpPost]
        public async Task<HttpResponseMessage> Upload()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = "C:\\Users\\Nguyen\\Desktop\\css";// HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new CustomMultipartFormDataStreamProvider(root);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.Size.ToString());
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                    //var result = new { name = file.LocalFileName };
                    //HttpContext.Current.Response.Write(serializer.Serialize(result));

                }
                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        //[HttpPost] // This is from System.Web.Http, and not from System.Web.Mvc
        //public async Task<HttpResponseMessage> Upload()
        //{
        //    if (!Request.Content.IsMimeMultipartContent())
        //    {
        //        this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
        //    }

        //    //var provider = GetMultipartProvider();
        //    string root = "C:\\Users\\Nguyen\\Desktop\\css";// HttpContext.Current.Server.MapPath("~/App_Data");
        //    var provider = new CustomMultipartFormDataStreamProvider(root);
        //    var result = await Request.Content.ReadAsMultipartAsync(provider);

        //    // On upload, files are given a generic name like "BodyPart_26d6abe1-3ae1-416a-9429-b35f15e6e5d5"
        //    // so this is how you can get the original file name
        //    var originalFileName = GetDeserializedFileName(result.FileData.First());

        //    // uploadedFileInfo object will give you some additional stuff like file length,
        //    // creation time, directory name, a few filesystem methods etc..
        //    var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);

        //    // Remove this line as well as GetFormData method if you're not 
        //    // sending any form data with your upload request
        //    //var fileUploadObj = GetFormData<UploadDataModel>(result);

        //    // Through the request response you can return an object to the Angular controller
        //    // You will be able to access this in the .success callback through its data attribute
        //    // If you want to send something to the .error callback, use the HttpStatusCode.BadRequest instead
        //    var returnData = uploadedFileInfo.Name;
        //    return this.Request.CreateResponse(HttpStatusCode.OK, new { returnData });
        //}

        //// You could extract these two private methods to a separate utility class since
        //// they do not really belong to a controller class but that is up to you
        //private MultipartFormDataStreamProvider GetMultipartProvider()
        //{
        //    var uploadFolder = "C:\\Users\\Nguyen\\Desktop\\css"; // you could put this to web.config
        //    //var root = HttpContext.Current.Server.MapPath(uploadFolder);
        //    //Directory.CreateDirectory(root);
        //    return new MultipartFormDataStreamProvider(uploadFolder);
        //}

        //// Extracts Request FormatData as a strongly typed model
        //private object GetFormData<T>(MultipartFormDataStreamProvider result)
        //{
        //    if (result.FormData.HasKeys())
        //    {
        //        var unescapedFormData = Uri.UnescapeDataString(result.FormData.GetValues(0).FirstOrDefault() ?? String.Empty);
        //        if (!String.IsNullOrEmpty(unescapedFormData))
        //            return JsonConvert.DeserializeObject<T>(unescapedFormData);
        //    }

        //    return null;
        //}

        //private string GetDeserializedFileName(MultipartFileData fileData)
        //{
        //    var fileName = GetFileName(fileData);
        //    return JsonConvert.DeserializeObject(fileName).ToString();
        //}

        //public string GetFileName(MultipartFileData fileData)
        //{
        //    return fileData.Headers.ContentDisposition.FileName;
        //}

    }

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

}
