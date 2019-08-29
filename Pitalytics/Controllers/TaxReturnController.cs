using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pitalytics.Repositories.Models;
using Pitalytics.Interfaces;
using Pitalytics.Domain.Models;

namespace Pitalytics.Controllers
{
    public class TaxReturnController : Controller
    {
        private readonly IGenerateDocumentService generateDocument;

        public TaxReturnController(IGenerateDocumentService generateDocument)
        {
            this.generateDocument = generateDocument;
        }


        /// <summary>
        /// Excels the specified tax return collection.
        /// </summary>
        /// <param name="taxReturnCollection">The tax return collection.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Excel(List<TaxReturnView> taxReturnCollection)
        {

            var title = "Report";

            Response.ClearContent();
            Response.BinaryWrite(generateDocument.GenerateExcel(taxReturnCollection, title));
            Response.AddHeader("content-disposition", "attachment; filename=Pitalytics.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Flush();
            Response.End();

            return RedirectToAction("GenerateReport", "TaxReturn");
        }

            // GET: TaxReturn
            public ActionResult Index()
        {
            return View();
        }
    }
}