using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FileUpload.Models;

namespace FileUpload.Controllers
{
    public class FileUploadController : ApiController
    {

        public HttpResponseMessage Upload()
        {
            var dbContext = new FileUploadEntities();
            var httpContext = HttpContext.Current;
            HttpResponseMessage result;
            if (httpContext.Request.Files.Count > 0)
            {
                var model = new Upload();
                model.UploadFiles = new List<UploadFile>();
                for (int i = 0; i < httpContext.Request.Files.Count; i++)
                {
                    HttpPostedFile httpPostedFile = httpContext.Request.Files[i];
                    var fileToUpload = new UploadFile();
                    fileToUpload.FileName = httpPostedFile.FileName;
                    fileToUpload.FileSize = httpPostedFile.ContentLength;
                    fileToUpload.FileType = httpPostedFile.ContentType;
                    fileToUpload.FileContent = new byte[httpPostedFile.InputStream.Length];
                    model.UploadFiles.Add(fileToUpload);
                }
                dbContext.Uploads.Add(model);
                dbContext.SaveChanges();
                result = Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }
    }
}
