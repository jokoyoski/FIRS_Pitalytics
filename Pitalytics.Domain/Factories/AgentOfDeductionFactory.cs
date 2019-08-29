using Pitalytics.Domain.Utilities;
using Pitalytics.Interfaces;
using Pitalytics.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pitalytics.Domain.Factories
{
    public class AgentOfDeductionFactory : IAgentOfDeductionFactory
    {
        #region

        /// <summary>
        /// Creates the branch ListView.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="branchCollection">The branch collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">branchCollection</exception>
        public IBranchListView CreateBranchListView(IList<IBranch> branchCollection,IList<IJurisdiction>jurisdictions,string infoMessage)
        {
            if (branchCollection == null)
            {
                throw new ArgumentNullException(nameof(branchCollection));
            }

            var jurisdictionDDL = GetJurisdictionDropdown.GetJurisdicions(jurisdictions, -1);
           

            var returnView = new BranchListView
            {
               
             BranchCollection=branchCollection,
             JurisdictionNames=jurisdictionDDL,
             ProcessingMessage=infoMessage,
            };
            return returnView;

        }




        /// <summary>
        /// Creates the tax report view.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <returns></returns>
        public ITaxReportView CreateTaxReportView(string infoMessage,IList<IIncomeType> incomeTypes, IDigitalFile fileType)
        {
            int? fileTypeId = 0;
            var incomeTypeDDL = GetDropdownIncomeTypeList.GetIncomeType(incomeTypes,-1);
           if(fileType!=null)
            {
              fileTypeId = fileType.DigitalFileId;
            }
            
            var taxReportView = new TaxReportView
            {
                FileTypeId = fileTypeId,
                ProcessingMessage = infoMessage,

                IncomeTypes=incomeTypeDDL,
            };
            return taxReportView;

        }


        /// <summary>
        /// Creates the branch view.
        /// </summary>
        /// <param name="branchView">The branch view.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">branchView</exception>
        public IBranchListView CreateBranchView(IBranchListView branchView)
        {
            if (branchView == null) throw new ArgumentNullException(nameof(branchView));
            var view = new BranchListView
            {
                ProcessingMessage = "",
                Description = branchView.Description,
                BranchId = branchView.BranchId

            };

            return view;
        }
        /// <summary>
        /// Gets the branch ListView.
        /// </summary>
        /// <param name="userRegistrations">The user registrations.</param>
        /// <param name="agentOfDeductionBranches">The agent of deduction branches.</param>
        /// <returns></returns>
        public IBranchListView GetBranchListView(IList<IBranch> branches)
        {



            var view = new BranchListView
            {
             BranchCollection=branches,

            };

            return view;
        }
        /// <summary>
        /// Creates the branch view.
        /// </summary>
        /// <param name="branchView">The branch view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">branchView</exception>
        public IBranchListView CreateBranchView(IBranchListView branchView, string processingMessage, IList<IJurisdiction> jurisdictions)
        {
            if (branchView == null)
            {
                throw new ArgumentException("branchView");
            }
            var jurisdictionDDL = GetJurisdictionDropdown.GetJurisdicions(jurisdictions, branchView.JurisdictionId);

            branchView.ProcessingMessage = processingMessage;
            branchView.JurisdictionNames = jurisdictionDDL;
            return branchView;
        }


        /// <summary>
        /// Creates the branch view.
        /// </summary>
        /// <param name="branches">The branches.</param>
        /// <returns></returns>
        public IBranchListView CreateBranchView(IList<IBranch>branches, string infomessage, IDigitalFile fileType)
        {
            int? fileTypeId = 0;
            if(fileType!=null)
            {
                fileTypeId = fileType.DigitalFileId;
            }
            var branchDDL = GetBranchDropdownList.BranchListItems(branches,-1);

            var branchView = new BranchListView
            {
                FileTypeId = fileTypeId,
                BranchNames =branchDDL,
                IncomeTypeNames = new List<SelectListItem>(),
                ProcessingMessage =infomessage,
            };
            return branchView;
        }



        /// <summary>
        /// Creates the branch view.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <returns></returns>
        public IBranchListView CreateBranchView(IBranch branch)
        {


            var branchView = new BranchListView
            {
               
              BranchName=branch.BranchName,
              BranchId=branch.BranchId
            };
            return branchView;
        }

        

        /// <summary>
        /// Creates the branch view.
        /// </summary>
        /// <returns></returns>
        public IBranchListView CreateBranchView(IList<IJurisdiction> jurisdictions)
        {

            var jurisdictionDDL = GetJurisdictionDropdown.GetJurisdicions(jurisdictions, -1);
            var view = new BranchListView
            {
                ProcessingMessage = string.Empty,
                JurisdictionNames = jurisdictionDDL
            };
            return view;
        }

        /// <summary>
        /// Gets the branch user ListView.
        /// </summary>
        /// <param name="userRegistrations">The user registrations.</param>
        /// <param name="branches">The branches.</param>
        /// <returns></returns>
        public IBranchListView GetBranchUserListView(IList<IUserRegistration> userRegistrations, IList<IBranch> branchesUsers,IList<IBranch>branches,string infoMessage,int branchId)
        {


            var userType = GetUserDropdown.UserListItems(userRegistrations, -1);

            var branchType = GetBranchDropdownList.BranchListItems(branches, -1);

            var view = new BranchListView
            {
                BranchCollection=branchesUsers,
                BranchNames = branchType,
                UserNames = userType,
                ProcessingMessage=infoMessage,
                BranchId=branchId
            };

            return view;
        }




        /// <summary>
        /// Gets the updated branch user ListView.
        /// </summary>
        /// <param name="userRegistrations">The user registrations.</param>
        /// <param name="branches">The branches.</param>
        /// <param name="branchUserListView">The branch user ListView.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IBranchListView GetUpdatedBranchUserListView(IList<IUserRegistration> userRegistrations, IList<IBranch> agentOfDeductionBranches, IBranchListView branchUserListView, string processingMessage)
        {


            var userType = GetUserDropdown.UserListItems(userRegistrations, branchUserListView.UserId);

            var branchType = GetBranchDropdownList.BranchListItems(agentOfDeductionBranches, branchUserListView.BranchId);


            var view = new BranchListView
            {

                BranchNames = branchType,
                UserNames = userType,
                ProcessingMessage = processingMessage
            };

            return view;
        }


        /// Gets the branch user ListView.
        /// </summary>
        /// <param name="userRegistrations">The user registrations.</param>
        /// <param name="branches">The branches.</param>
        /// <returns></returns>
        public IBranchListView GetBranchUserListView(IList<IBranch> branches)
        {




            var view = new BranchListView
            {

                BranchCollection = branches,

            };

            return view;
        }

        public IBranchListView GetBranchUserListView(IList<IUserRegistration> userRegistrations, IList<IBranch> branches)
        {


            var userType = GetUserDropdown.UserListItems(userRegistrations, -1);

            var branchType = GetBranchDropdownList.BranchListItems(branches, -1);

            var view = new BranchListView
            {
                BranchCollection = branches,
                BranchNames = branchType,
                UserNames = userType,

            };

            return view;
        }






        #endregion Branch


        #region Tax Returns        
        /// <summary>
        /// Gets the tax return ListView.
        /// </summary>
        /// <param name="taxReturns">The tax returns.</param>
        /// <param name="branches">The branches.</param>
        /// <param name="incomeTypes">The income types.</param>
        /// <returns></returns>
        public ITaxReturnListView GetTaxReturnListView(IList<ITaxReturn> taxReturns, IList<IBranch> branches,ITaxReturnListView taxReturnListView)
        {


           
            var branchType = GetBranchDropdownList.BranchListItems(branches, -1);


            var view = new TaxReturnListView
            {
                TaxReturnCollection=taxReturns,
               Incometype= new List<SelectListItem>(),
                Branch =branchType,
                SelectedBranchId=taxReturnListView.BranchId
            };

            return view;
        }




        /// <param name="branches">The branches.</param>
        /// <param name="incomeTypes">The income types.</param>
        /// <returns></returns>
        public ITaxReturnListView GetTaxReturnView(IList<ITaxReturn> taxReturns, IList<IAgentOfDeduction> agentOfDeductions,IList<IJurisdiction>jurisdictions ,ITaxReturnListView taxReturnListView)
        {





            var jurisdictionDDL = GetJurisdictionDropdown.GetJurisdicions(jurisdictions, -1);

            var agentOfDeductonDDL = GetAgentOfDeductionDropdown.AgentOfDeductionListItems(agentOfDeductions, -1);
                
            var view = new TaxReturnListView
            {
                TaxReturnCollection = taxReturns,
                Branch = new List<SelectListItem>(),
                JurisdictionList=jurisdictionDDL,
                AgentOfDeductionList=agentOfDeductonDDL,
                SelectedBranchId = taxReturnListView.BranchId,
                SelectedJursidctionId=taxReturnListView.JurisdictionId
            };

            return view;
        }
        #endregion

        #region TaxReport       
        /// <summary>
        /// Gets the tax report view.
        /// </summary>
        /// <param name="taxReports">The tax reports.</param>
        /// <param name="incomeReports">The income reports.</param>
        /// <returns></returns>
        public ITaxReportView GetTaxReportView(IList<ITaxReport> taxReports)
        {
            

            var view = new TaxReportView
            {
                TaxReportCollection = taxReports,
             
            };

            return view;
        }

        #endregion
    }
}


