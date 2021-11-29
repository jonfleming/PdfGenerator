using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

using Winnovative;

namespace PdfGenerator.Controllers
{
    public class PdfGeneratorController : ApiController
    {
        // POST api/PdfGenerator
        public HttpResponseMessage Post()
        {
            string htmlString;
            string filename = "file.pdf";

            using (StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream))
            {
                htmlString = reader.ReadToEnd();
            }

            HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();
            htmlToPdfConverter.LicenseKey = Environment.GetEnvironmentVariable("HtmlToPdfLicense");
            htmlToPdfConverter.ConversionDelay = 0;

            byte[] outPdfBuffer = null;
            outPdfBuffer = htmlToPdfConverter.ConvertHtml(htmlString, "");

            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(outPdfBuffer, 0, outPdfBuffer.Length);
            memoryStream.Position = 0;


            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(memoryStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = filename;
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }
    }
}
