using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pitalytics.Interfaces;
using Pitalytics.Domain.Models;

using Pitalytics.Domain.Attributes;
using AA.Infrastructure.Interfaces;

namespace Pitalytics.Controllers 
{
    public class AdministrationController : Controller
    {

        private readonly ISessionStateService session;

        /// <summary>
        //
        private readonly ILookupService lookUpService;
        private readonly IGeneralService generalService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrationController"/> class.
        /// </summary>
        /// <param name="lookUpService">The look up service.</param>
        /// <param name="generalService">The general service.</param>
        public AdministrationController(ILookupService lookUpService, IGeneralService generalService, ISessionStateService session)
        {
            this.lookUpService = lookUpService;
            this.generalService = generalService;
            this.session = session;
        }


        #region IncomeType

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult ReactivateIncomeType(int Id) 
        {
            var viewModel = this.generalService.ReactivateIncomeType(Id);
            return this.RedirectToAction("IncomeType", new { message = "IncomeType Reactivated" });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedIncomeTypeId"></param>
        /// <param name="selectedDescription"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ActionResult IncomeType(int? selectedIncomeTypeId, string selectedDescription, string message)
        {

            var IncomeTypeList = this.generalService.GetIncomeTypeViewModel(selectedIncomeTypeId ?? -1, selectedDescription, message);
            return View("IncomeType", IncomeTypeList);
        }






        /// <summary>
        /// Edits the type of the income.
        /// </summary>
        /// <param name="IncometypeId">The incometype identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">IncometypeId</exception>
        [HttpGet]
        public ActionResult EditIncomeType(int IncometypeId)
        {
            if (IncometypeId <= 0)
            {
                throw new ArgumentNullException(nameof(IncometypeId));
            }
            var incomeTypeModel = this.generalService.GetSelectedIncomeType(IncometypeId, "");
            return this.PartialView("EditIncomeType", incomeTypeModel);
        }

        ///// <summary>
        ///// Edits the type of the income.
        /// </summary>
        /// <param name="incometypeView">The incometype view.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditIncomeType(IncomeTypeListView incomeTypeView)
        {

            if (incomeTypeView == null)
            {
                throw new ArgumentNullException("incomeTypeView");
            }


            if (incomeTypeView.IncomeTypeName==null)
            {
                ModelState.AddModelError("", "Income Type Name is Required");
                var incomeTypeModel = this.generalService.GetIncomeTypeView(incomeTypeView, string.Empty);

                return this.View("EditIncomeType", incomeTypeModel);
            }

            var incomeTypeEdit = this.generalService.UpdateIncomeTypeInfo(incomeTypeView);

            if (!string.IsNullOrEmpty(incomeTypeEdit))
            {
                ModelState.AddModelError("", incomeTypeEdit);
                var incomeTypeModel = this.generalService.GetIncomeTypeView(incomeTypeView, "");
                return this.PartialView("EditIncomeType", incomeTypeModel);
            }

            var returnMessage = string.Format("IncomeType Updated ");

            return this.RedirectToAction("IncomeType",
                new { message = returnMessage });

        }






        /// <summary>
        /// Adds the type of the income.
        /// </summary>
        /// <param name="incomeTypeView">The income type view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">incomeTypeView</exception>
        [HttpPost]
        public ActionResult AddIncomeType(IncomeTypeListView incomeTypeView)
        {
            if (incomeTypeView == null)
            {
                throw new ArgumentNullException(nameof(incomeTypeView));
            }

            if (incomeTypeView.IncomeTypeName==null)
            {
                ModelState.AddModelError("", "Income Type Name is Required");
                var incomeTypeModel = this.generalService.GetIncomeTypeView(incomeTypeView, string.Empty);
                return this.PartialView("AddIncomeType", incomeTypeModel);
            }


            var incomeTypeInfo = this.generalService.ProcessIncomeTypeInfo(incomeTypeView);

            if (!string.IsNullOrEmpty(incomeTypeInfo))
            {
                ModelState.AddModelError("", incomeTypeInfo);
                var incomeType = this.generalService.GetIncomeTypeView(incomeTypeView, "");
                return this.PartialView("AddIncomeType", incomeType);
            }

            var returnMessage = string.Format("IncomeType Saved");

            var incomeTypeList = this.generalService.GetIncomeTypeView(incomeTypeView, returnMessage);
            return this.PartialView("AddIncomeType", incomeTypeList);

        }





        /// <summary>
        /// Incomes the type jurisdiction.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <param name="infoMessage">The information message.</param>
        /// <returns></returns>
        public ActionResult IncomeTypeJurisdiction(int jurisdictionId, string infoMessage)  //displays branches with the users
        {

            var incomeTypeJurisdictionList = this.generalService.GetJurisdictionIncomeType(jurisdictionId, infoMessage);
            return View("IncomeTypeJurisdiction", incomeTypeJurisdictionList);
        }



        /// <summary>
        /// Adds the income type jurisdiction.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddIncomeTypeJurisdiction()  //displays branches with the users
        {

            var incomeTypeList = this.generalService.GetIncomeTypeListView();
            return this.PartialView("IncomeTypeJurisdiction", incomeTypeList);
        }

        /// <summary>

        /// Adds the branch user.
        /// </summary>
        /// <param name="branchUserListView">The branch user ListView.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddIncomeTypeJurisdiction(IncomeTypeListView incomeTypeListView)  //displays branches with the users
        {

          
            if (incomeTypeListView.JurisdictionId == -1||incomeTypeListView.IncomeTypeId==-1)
            {
                ModelState.AddModelError("", "Ensure you select the appropriate Information");
                var incomeTypeJurisdiction = this.generalService.CreateUpdatedIncomeTypeJurisdictionView(incomeTypeListView, string.Empty);
                return this.PartialView("AddIncomeTypejurisdiction", incomeTypeJurisdiction);
            }


            var incomeTypeJurisdictionList = this.generalService.ProcessIncomeTypeJurisdictionInfo(incomeTypeListView);
            if (!string.IsNullOrEmpty(incomeTypeJurisdictionList))
            {
                var incomeTypeJurisdiction = this.generalService.CreateUpdatedIncomeTypeJurisdictionView(incomeTypeListView, incomeTypeJurisdictionList);
                return this.PartialView("AddIncomeTypejurisdiction", incomeTypeJurisdiction);


            }
            var returnModel = this.generalService.CreateUpdatedIncomeTypeJurisdictionView(incomeTypeListView, "Saved Successfully");
            return this.PartialView("AddIncomeTypejurisdiction", returnModel);



        }

        /// <summary>
        /// Deletes the income type jurisdiction.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <returns></returns>
        public ActionResult DeleteIncomeTypeJurisdiction(int jurisdictionId, int incomeTypeId)
        {

            var branchUserList = this.generalService.ProcessDeleteIncomeTypeJurisdictionInfo(jurisdictionId, incomeTypeId);
            return RedirectToAction("IncomeTypeJurisdiction", new { jurisdictionId = jurisdictionId, infoMessage = "Deactivated Successfully" });
        }






        /// <summary>
        /// Deletes the type of the income.
        /// </summary>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">incomeTypeId</exception>

        public ActionResult DeleteIncomeType(int incomeTypeId, string btnSubmit)
        {
            if (incomeTypeId < 1)
            {
                throw new ArgumentOutOfRangeException("incomeTypeId");
            }

            var message = this.generalService.ProcessDeleteIncomeTypeInfo(incomeTypeId);


            var returnMessage = string.Format("IncomeType Deleted");

            return this.RedirectToAction("IncomeType",
                new { message = returnMessage });
        }
    

        

      
        /// <summary>
        /// Deletes the type of the income.
        /// </summary>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">incomeTypeId</exception>
   
       
        #endregion

        #region AgentOfDeduction

        /// <summary>
        /// Agents the of deduction.
        /// </summary>
        /// <param name="selectedAgentOfDeductionId">The selected agent of deduction identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult AgentOfDeduction(int? selectedAgentOfDeductionId, string selectedDescription, string message)
        {
            var agentOfDeductionList = this.generalService.GetAgentOfDeductionViewModel(selectedAgentOfDeductionId ?? 0, selectedDescription, message);
            return View("AgentOfDeduction", agentOfDeductionList);
        }

        /// <summary>
        /// Deactivates the agent of deduction.
        /// </summary>
        /// <param name="agentOfDeductionId">The agent of deduction identifier.</param>
        /// <returns></returns>
        public ActionResult DeactivateAgentOfDeduction(int agentOfDeductionId)
        {
            var agentOfDeductionInfo = this.generalService.DeactivateAgentOfDeduction(agentOfDeductionId);
            return RedirectToAction("AgentOfDeduction", new { message = "Agent Of Deduction Deactivated" });
        }

        /// <summary>
        /// Deactivates the agent of deduction.
        /// </summary>
        /// <param name="agentOfDeductionId">The agent of deduction identifier.</param>
        /// <returns></returns>
        public ActionResult ActivateAgentOfDeduction(int agentOfDeductionId)
        {
            var agentOfDeductionInfo = this.generalService.ActivateAgentOfDeduction(agentOfDeductionId);
            return RedirectToAction("AgentOfDeduction", new { message = "Agent Of Deduction Activated" });
        }

        #endregion





        #region TaxAuthority        
        

        /// <summary>
        /// Taxes the authority.
        /// </summary>
        /// <param name="selectedTaxAuthorityId">The selected tax authority identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult TaxAuthority(int? selectedTaxAuthorityId, string selectedDescription, string message)
        {
            var taxAuthorityList = this.generalService.GetTaxAuthorityListViewModel(selectedTaxAuthorityId ?? 0, selectedDescription, message);
            return View("TaxAuthority", taxAuthorityList);
        }







        /// <summary>
        /// Deactivates the tax authority.
        /// </summary>
        /// <param name="taxAuthorityId">The tax authority identifier.</param>
        /// <returns></returns>
        public ActionResult DeactivateTaxAuthority(int taxAuthorityId)
        {
            var agentOfDeductionInfo = this.generalService.DeActivateTaxAuthority(taxAuthorityId);
            return RedirectToAction("TaxAuthority", new { message = "Tax Authority Deactivated" });
        }

       
        public ActionResult ActivateTaxAuthority(int taxAuthorityId)
        {
            var agentOfDeductionInfo = this.generalService.ActivateTaxAutority(taxAuthorityId);
            return RedirectToAction("TaxAuthority", new { message = "Tax Authority Activated" });
        }

        #endregion

       #region jurisdiction 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult ReactivateJurisidcition(int Id)
        {
            var viewModel = this.generalService.ReactivateJurisidcition(Id);
            return this.RedirectToAction("Jurisdiction", new { message = "Jurisdiction Reactivated" });
        }


        /// <summary>
        /// Jurisdictions the specified selected jurisidcition identifier.
        /// </summary>
        /// <param name="selectedJurisidcitionId">The selected jurisidcition identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult Jurisdiction(int? selectedJurisidcitionId, string selectedDescription, string message)
        {
            var jurisdictionList = this.generalService.GetJurisdictionListViewModel(selectedJurisidcitionId ?? 0, selectedDescription, message);
            return View("Jurisdiction", jurisdictionList);
        }

        /// <summary>
        /// Edits the jurisdiction.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">jurisdictionId</exception>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult EditJurisdiction(int jurisdictionId)
        {
            if (jurisdictionId <= 0)
            {
                throw new ArgumentNullException(nameof(jurisdictionId));
            }

            var viewModel = this.generalService.GetSelectedJurisdictionByInfo(jurisdictionId);
            return this.PartialView("EditJurisdiction", viewModel);
        }

        /// <summary>
        /// Edits the jurisdiction.
        ///// </summary>
        ///// <param name="jurisdictionView">The jurisdiction view.</param>
        ///// <returns></returns>
        ///// <exception cref="ArgumentNullException">jurisdictionView</exception>
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult EditJurisdiction(JurisdictionListView jurisdictionView)
        {
            if (jurisdictionView == null)
            {
                throw new ArgumentNullException("jurisdictionView");
            }

            if (!ModelState.IsValid)
            {
                var JurisdictionModel = this.generalService.GetJurisdictionView(jurisdictionView, string.Empty);

                return this.View("EditJurisdiction", JurisdictionModel);
            }

            var jurisdictionEdit = this.generalService.UpdateJurisdictionInfo(jurisdictionView);

            if (!string.IsNullOrEmpty(jurisdictionEdit))
            {
                ModelState.AddModelError("", jurisdictionEdit);
                var JurisdictionModel = this.generalService.GetJurisdictionView(jurisdictionView, "");
                return View("EditJurisdiction", JurisdictionModel);
            }

            var returnMessage = string.Format("Jurisdiction Updated ");

            return this.RedirectToAction("Jurisdiction",
                new { message = returnMessage });
        }
        /// <summary>
        /// Adds the jurisdiction.
        /// </summary>
        /// <returns></returns>

        public ActionResult AddJurisdiction()

        {
            var viewModel = this.generalService.GetJurisdictionView();
            return this.PartialView("AddJurisdiction", viewModel);
        }
        /// <summary>
        /// Adds the jurisdiction.
        /// </summary>
        /// <param name="jurisdictionrView">The jurisdictionr view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">jurisdictionrView</exception>

        [HttpPost]
        public ActionResult AddJurisdiction(JurisdictionListView jurisdictionView)
        {
            if (jurisdictionView == null)
            {
                throw new ArgumentNullException(nameof(jurisdictionView));
            }

            if (!ModelState.IsValid)
            {
                var jurisdictionModel = this.generalService.GetJurisdictionView(jurisdictionView, string.Empty);
                return this.PartialView("AddJurisdiction", jurisdictionModel);
            }


            var jurisdictionInfo = this.generalService.ProcessJurisdictionInfo(jurisdictionView);
            if (!string.IsNullOrEmpty(jurisdictionInfo))
            {
                ModelState.AddModelError("", jurisdictionInfo);
                var jurisdictionModel = this.generalService.GetJurisdictionView(jurisdictionView, "");
                return this.PartialView("AddJurisdiction", jurisdictionModel);
            }

            var returnMessage = string.Format("Jurisdiction Saved");

            var jurisdictionList = this.generalService.GetJurisdictionView(jurisdictionView, returnMessage);
            return this.PartialView("AddJurisdiction", jurisdictionList);
        }





        public ActionResult DeleteJurisdiction(int jurisdictionId, string btnSubmit)
        {
            if (jurisdictionId < 1)
            {
                throw new ArgumentOutOfRangeException("jurisdictionId");
            }

            var message = this.generalService.ProcessDeleteJurisdictionInfo(jurisdictionId);


            var returnMessage = string.Format("Jurisdiction Deleted");

            return this.RedirectToAction("Jurisdiction",
                new { message = returnMessage });
        }

        #endregion


        #region Industry 

        [HttpGet]
        [CheckUserLogin()]
        public ActionResult ReactivateIndustry(int Id)
        {
            var viewModel = this.generalService.ReactivateIndustry(Id);
            return this.RedirectToAction("Industry",new {message="Industry Reactivated" });
        }
        /// <summary>
        /// Industries the specified selected industry identifier.
        /// </summary>
        /// <param name="selectedIndustryId">The selected industry identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>

        public ActionResult Industry(int? selectedIndustryId, string selectedDescription, string message)
        {
            var industryList = this.generalService.GetIndustryListViewModel(selectedIndustryId ?? 0, selectedDescription, message);
            return View("Industry", industryList);
        }

        /// <summary>
        /// Edits the industry.
        /// </summary>
        /// <param name="industryId">The industry identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditIndustry(int industryId)
        {
            if (industryId <= 0)
            {
                throw new ArgumentNullException(nameof(industryId));
            }

            var viewModel = this.generalService.GetSelectedIndustryByInfo(industryId);
            return this.PartialView("EditIndustry", viewModel);
        }


        [HttpPost]
        public ActionResult EditIndustry(IndustryListView industryView)
        {

            if (industryView == null)
            {
                throw new ArgumentNullException("industryView");
            }

            if (!ModelState.IsValid)
            {
                var incomeTypeModel = this.generalService.GetIndustryView(industryView, string.Empty);

                return this.View("EditIndustry", industryView);
            }

            var industryEdit = this.generalService.UpdateIndustryInfo(industryView);

            if (!string.IsNullOrEmpty(industryEdit))
            {
                ModelState.AddModelError("", industryEdit);
                var industryModel = this.generalService.GetIndustryView(industryView,"");
                return View("EditIndustry", industryModel);
            }

            var returnMessage = string.Format("Industry Updated ");

            return this.RedirectToAction("Industry",
                new { message = returnMessage });

        }
        /// <summary>
        /// Adds the industry.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddIndustry()

        {
            var viewModel = this.generalService.GetIndustryView();
            return this.PartialView("AddIndustry", viewModel);
        }
        /// <summary>
        /// Adds the industry.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">industryView</exception>
        [HttpPost]
        public ActionResult AddIndustry(IndustryListView industryView)
        {
            if (industryView == null)
            {
                throw new ArgumentNullException(nameof(industryView));
            }

            if (!ModelState.IsValid)
            {
                var industryModel = this.generalService.GetIndustryView(industryView, string.Empty);
                return this.PartialView("AddIndustry", industryModel);
            }

            var industryInfo = this.generalService.ProcessIndustryInfo(industryView);
            if (!string.IsNullOrEmpty(industryInfo))
            {
                ModelState.AddModelError("", industryInfo);
                var industryModel = this.generalService.GetIndustryView(industryView, "");

                return PartialView("AddIndustry", industryModel);
            }
            var industrySave = "    Industry Saved";
            var industry = this.generalService.GetIndustryView(industryView, industrySave);
            return PartialView("AddIndustry", industry);
        }

        ///
        public ActionResult DeleteIndustry(int industryId, string btnSubmit)
        {
            if (industryId < 1)
            {
                throw new ArgumentOutOfRangeException("industryId");
            }

            var message = this.generalService.ProcessDeleteIndustryInfo(industryId);


            var returnMessage = string.Format("Industry Deleted");

            return this.RedirectToAction("Industry",
                new { message = returnMessage });
        }
        #endregion


        #region Inland Revenue Setup

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [CheckUserLogin()]
        public ActionResult ReactivateInlandRevenue(int Id) 
        {
            var viewModel = this.generalService.ReactivateInlandRevenue(Id);
            return this.RedirectToAction("InlandRevenue",new { message = "InlandRevenue Reactivated" });
        }
        /// <summary>
        /// Inlands the revenue.
        /// </summary>
        /// <param name="selectedInlandRevenueId">The selected inland revenue identifier.</param>
        /// <param name="selectedInlandRevenueName">Name of the selected inland revenue.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult InlandRevenue(int? selectedInlandRevenueId, string selectedInlandRevenueName, string message)
        {
            var inlandRevenueList = this.generalService.GetInlandRevenueListViewModel(selectedInlandRevenueId ?? 0, selectedInlandRevenueName, message);
            return View("InlandRevenue", inlandRevenueList);
        }

        /// <summary>
        /// Edits the inland revenue.
        /// </summary>
        /// <param name="inlandRevenueId">The inland revenue identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">inlandRevenueId</exception>
        [HttpGet]
        public ActionResult EditInlandRevenue(int inlandRevenueId)
        {
            if (inlandRevenueId <= 0)
            {
                throw new ArgumentNullException(nameof(inlandRevenueId));
            }

            var inlandRevenueModel = this.generalService.GetSelectedInlandRevenue(inlandRevenueId, "");
            return this.PartialView("EditInlandRevenue", inlandRevenueModel);
        }

        [HttpPost]
        public ActionResult EditInlandRevenue(InlandRevenueListView inlandRevenueview)
        {

            if (inlandRevenueview == null)
            {
                throw new ArgumentNullException("inlandRevenueview");
            }

            if (!ModelState.IsValid)
            {
                var inlandRevenueModel = this.generalService.GetInlandRevenueView(inlandRevenueview, string.Empty);

                return this.View("EditInlandRevenue", inlandRevenueModel);
            }

            var inlandRevenueEdit = this.generalService.UpdateInlandRevenueInfo(inlandRevenueview);

            if (!string.IsNullOrEmpty(inlandRevenueEdit))
            {
                ModelState.AddModelError("", inlandRevenueEdit);
                var inlandRevenueModel = this.generalService.GetInlandRevenueView(inlandRevenueview, "");
                return View("EditInlandRevenue", inlandRevenueModel);
            }

            var returnMessage = string.Format("Inland Revenue Updated ");

            return this.RedirectToAction("InlandRevenue",
                new { message = returnMessage });

        }

        /// <summary>
        /// Adds the inland revenue.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddInlandRevenue()

        {
            var viewModel = this.generalService.GetInlandRevenueView();
            return this.PartialView("AddInlandRevenue", viewModel);
        }

        /// <summary>
        /// Adds the inland revenue.
        /// </summary>
        /// <param name="inlandRevenueView">The inland revenue view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">inlandRevenueView</exception>
        [HttpPost]
        public ActionResult AddInlandRevenue(InlandRevenueListView inlandRevenueView)
        {
            if (inlandRevenueView == null)
            {
                throw new ArgumentNullException(nameof(inlandRevenueView));
            }

            if (!ModelState.IsValid)
            {
                var inlandRevenueModel = this.generalService.GetInlandRevenueView(inlandRevenueView, string.Empty);
                return this.PartialView("AddInlandRevenue", inlandRevenueModel);
            }


            var inlandRevenueInfo = this.generalService.ProcessInlandRevenueInfo(inlandRevenueView);
            if (!string.IsNullOrEmpty(inlandRevenueInfo))
            {
                ModelState.AddModelError("", inlandRevenueInfo);
                var inlandRevenueModel = this.generalService.GetInlandRevenueView(inlandRevenueView, "");
                return this.PartialView("AddInlandRevenue", inlandRevenueModel);
            }

            var inlandRevenueSave = "inlandRevenueSave";
            var inlandRevenue = this.generalService.GetInlandRevenueView(inlandRevenueView, inlandRevenueSave);
            return this.PartialView("AddInlandRevenue", inlandRevenue);
        }


        public ActionResult DeleteInlandRevenue(int inlandRevenueId, string btnSubmit)
        {
            if (inlandRevenueId < 1)
            {
                throw new ArgumentOutOfRangeException("inlandRevenueId");
            }

            var message = this.generalService.ProcessDeleteInlandRevenueInfo(inlandRevenueId);


            var returnMessage = string.Format("InlandRevenue Deleted");

            return this.RedirectToAction("InlandRevenue",
                new { message = returnMessage });
        }

        #endregion



        #region Upload Excel        
        /// <summary>
        /// Adds the upload excel.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUploadExcel()

        {
            var viewModel = this.generalService.GetUploadExcelView();
            return this.PartialView("AddUploadExcel", viewModel);
        }

        /// <summary>
        /// Adds the upload excel.
        /// </summary>
        /// <param name="excelSheet">The excel sheet.</param>
        /// <param name="digitalFileView">The digital file view.</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        [CheckUserLogin()]
        public ActionResult AddUploadExcel(HttpPostedFileBase excelSheet,DigitalFileView digitalFileView) 
        {

            if (digitalFileView == null)
            {
                throw new ArgumentNullException(nameof(digitalFileView));
            }

            if (!ModelState.IsValid)
            {
                var digitalFileViewModel = this.generalService.GetUploadExcelView(digitalFileView, string.Empty);
                return this.PartialView("AddUploadExcel", digitalFileViewModel);
            }

            var processingMessage = string.Empty;
            processingMessage = this.generalService.ProcessUploadExcelMainInfo(excelSheet, digitalFileView);

            var digitalFileSave = "File Saved";
            var digitalFile = this.generalService.GetUploadExcelView(digitalFileView, digitalFileSave);
            return this.PartialView("AddUploadExcel", digitalFile);

        }

        /// <summary>
        /// Files the result.
        /// </summary>
        /// <param name="fileId">The file identifier.</param>
        /// <returns></returns>
        public FileResult FileResult(int fileId)
        {
            var excelFile = generalService.GetExcelFileForDownload(fileId);


            return File(excelFile.FileContent, excelFile.ContentType);
        }
        #endregion

        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }
    }
}
