

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.DAG;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TicketWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        

        //[HttpGet]
        //public string getpdf()
        //{
        //    //PdfDocument pdf = new PdfDocument();
        //    //pdf.Info.Title = "My First PDF";
        //    //PdfPage pdfPage = pdf.AddPage();
        //    //XGraphics graph = XGraphics.FromPdfPage(pdfPage);
        //    //XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
        //    ////XFont font = new XFont("Verdana",20);
        //    //graph.DrawString("This is my first PDF document", font, XBrushes.Black, new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center);
        //    //string pdfFilename = "firstpage.pdf";
        //    //pdf.Save(pdfFilename);
        //    //Process.Start(pdfFilename);

        //    var myHtml = "<style>h1 {font-size:12px;}</style><h1>Test</h1><p style='font-weight:bold'>Test Bold</p>";
        //    var htmlToPdf = new HtmlToPdf();
        //    var pdf = htmlToPdf.RenderHtmlAsPdf(myHtml);
        //    pdf.SaveAs("output.pdf");
        //    return "";
        //}

    }
}
