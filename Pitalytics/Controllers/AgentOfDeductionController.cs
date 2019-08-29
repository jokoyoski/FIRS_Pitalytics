using Pitalytics.Domain.Attributes;
using Pitalytics.Domain.Models;
using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pitalytics.Controllers
{
    public class AgentOfDeductionController : Controller
    {


        /// <summary>
        /// The agent of deduction service
        /// </summary>
        private readonly IAgentOfDeductionService agentOfDeductionService;
        private readonly IGeneralService generalService;
        /// <summary>
        /// Initializes a new instance of the <see cref="AgentOfDeductionController"/> class.
        /// </summary>
        /// <param name="agentOfDeductionService">The agent of deduction service.</param>
        public AgentOfDeductionController(IAgentOfDeductionService agentOfDeductionService, IGeneralService generalService)
        {
            this.agentOfDeductionService = agentOfDeductionService;
            this.generalService = generalService;
        }
        // GET: AgentOfDeduction
        public ActionResult Index()
        {
            return View();
        }

        #region Branch Setup


   
        /// <summary>
        /// Branches the specified selected branch identifier.
        /// </summary>
        /// <param name="selectedBranchId">The selected branch identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult Branch(int? selectedBranchId, string selectedDescription, string message)
        {

            var branchList = this.agentOfDeductionService.GetBranchListView(message);
            return View("Branch", branchList);
        }

        

    
        

        /// <summary>
        /// Adds the branch.
        /// </summary>
        /// <param name="branchView">The branch view.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">branchView</exception>
        [HttpPost]
        public ActionResult AddBranch(BranchListView branchView)
        {
            if (branchView == null)
            {
                throw new ArgumentNullException(nameof(branchView));
            }
             
            if(branchView.JurisdictionId==-1)
            {

                this.ModelState.AddModelError("", "Jurisdiction cannot be empty");
                var branchModel = this.agentOfDeductionService.GetBranchView(branchView, string.Empty);
                return this.PartialView("AddBranch",branchModel);
            }

            if (!ModelState.IsValid)
            {
                var branchModel = this.agentOfDeductionService.GetBranchView(branchView, string.Empty);
                return this.PartialView("AddBranch", branchModel);
            }


            var branchInfo = this.agentOfDeductionService.ProcessBranchInfo(branchView);
            if (!string.IsNullOrEmpty(branchInfo))
            {
                ModelState.AddModelError("", branchInfo);
                var branchModel = this.agentOfDeductionService.GetBranchView(branchView, "");
                return this.PartialView("AddBranch", branchModel);
            }

            branchView = new BranchListView();

            var returnModel = this.agentOfDeductionService.GetBranchView(branchView, "Branch Added Successfully");

            return this.PartialView("AddBranch",returnModel);
        }

        /// <summary>
        /// Deletes the branch.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">branchId</exception>
        /// <exception cref="ArgumentOutOfRangeException">branchId</exception>
        ///// Deletes the branch.
        ///// </summary>
        ///// <param name="branchId">The branch identifier.</param>
        ///// <returns></returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">branchId</exception>
        //[HttpGet]
        //public ActionResult DeleteBranch(int branchId)
        //{
        //    if (branchId < 1)
        //    {
        //        throw new ArgumentOutOfRangeException("branchId");
        //    }

        //    var branchModel = this.agentOfDeductionService.GetSelectedBranchByInfo(branchId);
        //    return this.PartialView("DeleteBranch", branchModel);
        //}

        [HttpGet]
        public ActionResult EditBranch(int branchId)
        {
            if (branchId <= 0)
            {
                throw new ArgumentNullException(nameof(branchId));
            }
            var branchModel = this.agentOfDeductionService.GetSelectedBranchInfo(branchId);
            return this.PartialView("EditBranch", branchModel);
        }




        /// <summary>
        /// Edits the branch.
        /// </summary>
        /// <param name="branchListView">The branch ListView.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">incomeTypeView</exception>
        [HttpPost]
        public ActionResult EditBranch(BranchListView branchListView)
        {

            if (branchListView == null)
            {
                throw new ArgumentNullException("branchListView");
            }

            if (!ModelState.IsValid)
            {
                var branchTypeModel = this.agentOfDeductionService.GetBranchView(branchListView, string.Empty);

                return this.View("EditBranch", branchTypeModel);
            }

            var branchTypeEdit = this.agentOfDeductionService.UpdateBranchInfo(branchListView);

            if (!string.IsNullOrEmpty(branchTypeEdit))
            {
                ModelState.AddModelError("", branchTypeEdit);
                var incomeTypeModel = this.agentOfDeductionService.GetBranchView(branchListView, "");
                return View("EditBranch", incomeTypeModel);
            }

            var returnMessage = string.Format("BranchType Updated ");

            return this.RedirectToAction("Branch",
                new { message = returnMessage });

        }
        /// <summary>
        /// Deletes the branch.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">branchId</exception>
        [HttpGet]
        public ActionResult DeleteBranch(int branchId, string btnSubmit)
        {
            if (branchId < 1)
            {
                throw new ArgumentOutOfRangeException("branchId");
            }

            var message = this.agentOfDeductionService.ProcessDeleteBranchInfo(branchId);


            var returnMessage = string.Format("Branch Deleted");

            return this.RedirectToAction("Branch",
                new { message = returnMessage });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <param name="btnSubmit"></param>
        /// <returns></returns>
        public ActionResult ReactivateBranch(int branchId, string btnSubmit)
        {
            if (branchId < 1)
            {
                throw new ArgumentOutOfRangeException("branchId");
            }

            var message = this.agentOfDeductionService.ReactivateBranchInfo(branchId);


            var returnMessage = string.Format("Branch Reactivated");

            return this.RedirectToAction("Branch",
                new { message = returnMessage });
        }



        /// <summary>
        /// Adds the branch user.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddBranchUser()  //displays branches with the users
        {

            var branchUserList = this.agentOfDeductionService.GetBranchUserView();
            return this.PartialView("BranchUser", branchUserList);
        }

        /// <summary>

        /// Adds the branch user.
        /// </summary>
        /// <param name="branchUserListView">The branch user ListView.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddBranchUser(BranchListView branchUserListView)  //displays branches with the users
        {
            var user = this.agentOfDeductionService.CheckUserBranchExist(branchUserListView.UserId, branchUserListView.BranchId);
            if (user)
            {
                var processingMessage = "User Already Assigned";
               var userInfo= this.agentOfDeductionService.GetUpdatedBranchUserListView(branchUserListView, processingMessage);
                return this.PartialView("AddBranchUser", userInfo);
            }
            if(!ModelState.IsValid)
            {
               
                var userInfo = this.agentOfDeductionService.GetUpdatedBranchUserListView(branchUserListView, "");
                return this.PartialView("AddBranchUser", userInfo);
            }
            if(branchUserListView.UserId==-1)
            {
                var processingMessage = "User  Is Required";
                var userInfo = this.agentOfDeductionService.GetUpdatedBranchUserListView(branchUserListView, processingMessage);
                return this.PartialView("AddBranchUser", userInfo);
            }

            var branchUserList = this.agentOfDeductionService.SaveBranchUserInfo(branchUserListView);
            if(!string.IsNullOrEmpty(branchUserList))
            {
                ModelState.AddModelError("", branchUserList);
                var userInfo = this.agentOfDeductionService.GetUpdatedBranchUserListView(branchUserListView, "");
                return this.PartialView("AddBranchUser", userInfo);
            }
            var returnView = this.agentOfDeductionService.GetUpdatedBranchUserListView(branchUserListView, "User Assigned Successfully");
            return this.PartialView("AddBranchUser", returnView);
        }

        /// <summary>
        /// Branches the user.
        /// </summary>
        /// <param name="selectedIncomeTypeId">The selected income type identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult BranchUser(int branchId,string infoMessage)  //displays branches with the users
        {

            var branchUserList = this.agentOfDeductionService.GetBranchUserListView(branchId,infoMessage);
            return View("BranchUser", branchUserList);
        }
        /// <summary>
        /// Deletes the branch user.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        public ActionResult DeleteBranchUser(int branchId, int userId)
        {

            var branchUserList = this.agentOfDeductionService.DeleteUserBranch(userId, branchId);
            return RedirectToAction("BranchUser", new {branchId=branchId, infoMessage="User Deactivated Successfully" });
        }

        /// <summary>
        /// Reactivates the branch user.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public ActionResult ReactivateBranchUser(int branchId, int userId)
        {

            var branchUserList = this.agentOfDeductionService.ReactivateUserBranch(userId, branchId);
            return RedirectToAction("BranchUser", new { branchId = branchId, infoMessage = "User activated Successfully" });
        }




        #endregion







        #region Tax Returns   



        #region AgentOfDeduction
        /// <summary>
        /// Taxes the returns.
        /// </summary>
        /// <returns></returns>
        public ActionResult TaxReturns(TaxReturnListView taxReturnListView)
        {
            var taxReturns = this.agentOfDeductionService.GetTaxReturnsListView(taxReturnListView);
            return View(taxReturns);
        }
        /// <summary>
        /// Adds the taxreturns.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddTaxreturns(string infoMessage)
        {
            var view = this.agentOfDeductionService.GetTaxreturnsView(infoMessage);


            return this.View("AddTaxReturns", view);

        }


        /// <summary>
        /// Adds the tax returns.
        /// </summary>
        /// <param name="taxReturnFile">The tax return file.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddTaxReturns(HttpPostedFileBase employeeExcelSheet, TaxReturnView taxReturnView)
        {
            if (taxReturnView.IncomeTypeId < 1)
            {
                this.ModelState.AddModelError("", "Please specify Income Type");
            }

            if (taxReturnView.BranchId < 1)
            {
                this.ModelState.AddModelError("", "Please specify Branch");
                var view = this.agentOfDeductionService.GetTaxreturnsView("");
                return this.View("AddTaxReturns", view);
            }


            var returnInfo = this.agentOfDeductionService.ProcessUploadExcel(employeeExcelSheet, taxReturnView.IncomeTypeId, taxReturnView.BranchId);

            if (!string.IsNullOrEmpty(returnInfo))
            {
                var returnModel = this.agentOfDeductionService.GetTaxreturnsView(returnInfo);
                return this.View("AddTaxReturns", returnModel);
            }
            var returnView = this.agentOfDeductionService.GetTaxreturnsView("File Uploaded Successfully");
            return this.View("AddTaxReturns", returnView);
        }




        public JsonResult FetchIncomeType(int branchId)
        {
            var incometypes = this.generalService.GetIncomeTypeByBranchId(branchId);

            return this.Json(incometypes, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region Tax Authority       
        /// <returns></returns>    //this displays tax returns for tax authority
        public ActionResult TaxAuthorityTaxReturns(TaxReturnListView taxReturnListView)
        {
            var taxReturns = this.agentOfDeductionService.GetTaxAuthorityTaxReturnsView(taxReturnListView);
            return View(taxReturns);
        }
        #endregion

        #region SystemAdmin
        public ActionResult SystemAdminTaxReturns(TaxReturnListView taxReturnListView)
        {
            var taxReturns = this.agentOfDeductionService.GetSystemAdminTaxReturnsView(taxReturnListView);
            return View(taxReturns);
        }
        #endregion
        public JsonResult FetchBranchList(int agentId)
        {
            var branchTypes = this.agentOfDeductionService.GetBranchByAgentOfDeduction(agentId);

            return this.Json(branchTypes, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region Tax Report   


        /// <summary>
        /// Taxes the report.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public ActionResult AddTaxReport(string processingMessage)
        {
            var taxReport = this.agentOfDeductionService.GetTaxReportView(processingMessage);
            return View(taxReport);
        }

        /// <summary>
        /// Adds the tax report.
        /// </summary>
        /// <param name="taxReportExcelSheet">The tax report excel sheet.</param>
        /// <param name="taxReportView">The tax report view.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddTaxReport(HttpPostedFileBase taxReportExcelSheet, TaxReportView taxReportView)
        {

            var returnInfo = this.agentOfDeductionService.ProcessUploadExcel(taxReportExcelSheet, taxReportView);

            if (!string.IsNullOrEmpty(returnInfo))
            {
                var returnModel = this.agentOfDeductionService.GetTaxReportView(returnInfo);
                return this.View("AddTaxReport", returnModel);
            }
            var returnView = this.agentOfDeductionService.GetTaxReportView("File Uploaded Successfully");
            return this.View("AddTaxReport", returnView);
        }

        /// <summary>
        /// Reports the specified tax report view.
        /// </summary>
        /// <param name="taxReportView">The tax report view.</param>
        /// <returns></returns>
        public ActionResult TaxReport (TaxReportView taxReportView)
        {
            


            var taxReport = this.agentOfDeductionService.GetTaxReportView(taxReportView.BVN, taxReportView.Year);

            return this.View("TaxReport", taxReport);
        }

        #endregion
    }
}