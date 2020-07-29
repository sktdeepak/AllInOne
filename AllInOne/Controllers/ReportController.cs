//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Reporting.WebForms;

//namespace AllInOne.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ReportController : ControllerBase
//    {
//        [HttpGet]
//        [Route("MyReport")]
//        public IActionResult GetReport() {
//            var reportViewer = new ReportViewer { ProcessingMode = ProcessingMode.Local };
//            reportViewer.LocalReport.ReportPath = "Reports/MyReport.rdlc";

//            //reportViewer.LocalReport.DataSources.Add(new ReportDataSource("NameOfDataSource1", new DataTable()));
//            //reportViewer.LocalReport.DataSources.Add(new System.Web.ReportDataSource("NameOfDataSource2", new DataTable()));

//            Warning[] warnings;
//            string[] streamids;
//            string mimeType;
//            string encoding;
//            string extension;

//            var bytes = reportViewer.LocalReport.Render("application/pdf", null, out mimeType, out encoding, out extension, out streamids, out warnings);

//            return File(bytes, "application/pdf");
//}
//    }
//}