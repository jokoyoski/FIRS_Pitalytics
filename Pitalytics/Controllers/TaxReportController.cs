using Pitalytics.Domain.Models;
using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pitalytics.Controllers
{
    public class TaxReportController : Controller
    {
        private readonly IGenerateDocumentService generateDocument;

        public TaxReportController(IGenerateDocumentService generateDocument)
        {
            this.generateDocument = generateDocument;
        }


        /// <summary>
        /// Excels the specified tax return collection.
        /// </summary>
        /// <param name="taxReturnCollection">The tax return collection.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Excel(List<TaxReportView> taxReportCollection)
        {

            var title = "Tax Report";

            Response.ClearContent();
            Response.BinaryWrite(generateDocument.GenerateExcel(taxReportCollection, title));
            Response.AddHeader("content-disposition", "attachment; filename=TaxReport.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Flush();
            Response.End();

            return RedirectToAction("GenerateReport", "TaxReport");
        }

        // GET: TaxReturn
        public ActionResult Index()
        {
            return View();
        }
    }
}