using AA.Infrastructure.Interfaces;
using Pitalytics.Domain.Models;
using Pitalytics.Domain.Resources;
using Pitalytics.Interfaces;
using Pitalytics.Interfaces.ValueTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pitalytics.Domain.Services
{
    public class AgentOfDeductionService : IAgentOfDeductionService
    {
        private readonly IEnvironment environment;
        private readonly IAgentOfDeductionRepository agentOfDeductionRepository;
        private readonly IAgentOfDeductionFactory agentOfDeductionFactory;
        private readonly ISessionStateService session;
        private readonly IAccountRepository accountRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly IDigitalFileRepository digitalFileRepository;

        public AgentOfDeductionService(IEnvironment environment, IAccountRepository accountRepository, IDigitalFileRepository digitalFileRepository, IGeneralRepository generalRepository, IAgentOfDeductionRepository agentOfDeductionRepository, IAgentOfDeductionFactory agentOfDeductionFactory, ISessionStateService session)
        {

            this.agentOfDeductionFactory = agentOfDeductionFactory;
            this.agentOfDeductionRepository = agentOfDeductionRepository;
            this.accountRepository = accountRepository;
            this.session = session;
            this.environment = environment;
            this.generalRepository = generalRepository;
            this.digitalFileRepository = digitalFileRepository;
        }

        #region  Branch




        /// <summary>
        //// Gets the branch view.
        /// </summary>
        // / <param name = "branchView" > The branch view.</param>
        //  / <param name = "message" > The message.</param>
        // / <returns></returns>
        public IBranchListView GetBranchView(IBranchListView branchView, string message)
        {

            var jurisdiction = this.generalRepository.GetJurisdiction();
            jurisdiction = jurisdiction.Where(x => x.IsActive == true).ToList();
            return this.agentOfDeductionFactory.CreateBranchView(branchView, message, jurisdiction);
        }


        /// <summary>
        /// Gets the selected branch information.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        public IBranchListView GetSelectedBranchInfo(int branchId)
        {

            var branchInfo = this.agentOfDeductionRepository.GetBranchById(branchId);
            return this.agentOfDeductionFactory.CreateBranchView(branchInfo);
        }

        /// <summary>
        /// Updates the branch information.
        /// </summary>
        /// <param name="branchView">The branch view.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">branchView</exception>
        public string UpdateBranchInfo(IBranchListView branchView)
        {
            if (branchView == null)
            {
                throw new ArgumentNullException(nameof(branchView));
            }


            var processingMessages = string.Empty;

            var dataValue = this.agentOfDeductionRepository.GetBranchDescriptionByValue(branchView.BranchName);
            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.BranchExist;
                return processingMessages;
            }


            var editBranch = this.agentOfDeductionRepository.EditBranch(branchView);

            return editBranch;
        }

        /// <summary>
        /// Gets the branch view.
        /// </summary>
        /// <returns></returns>
        public IBranchListView GetBranchView()
        {
            var jurisdiction = this.generalRepository.GetJurisdiction();
            return this.agentOfDeductionFactory.CreateBranchView(jurisdiction);
        }

        /// <summary>
        /// Processes the branch information.
        /// </summary>
        /// <param name="branchView">The branch view.</param>
        /// <returns></returns>
        public string ProcessBranchInfo(IBranchListView branchView)
        {

            var processingMessages = string.Empty;

            var dataValue = this.agentOfDeductionRepository.GetBranchDescriptionByValue(branchView.BranchName);
            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.BranchExist;
                return processingMessages;
            }
            var branchId = 0;
            var branchInfo = this.agentOfDeductionRepository.SaveBranchInfo(branchView, out branchId);
            if (string.IsNullOrEmpty(branchInfo))
            {

                var userId = (int)session.GetSessionValue(SessionKey.UserId); ;
                BranchListView branchUserListView = new BranchListView
                {
                    BranchId = branchId,
                    UserId = userId
                };
                var agentId = (int)session.GetSessionValue(SessionKey.AgentOfDeductionId); ;

                AgentOfDeductionBranchView agentOfDeductionView = new AgentOfDeductionBranchView()
                {
                    AgentOfDeductionId = agentId,
                    BranchId = branchId
                };
                BranchJurisdictionView branchJurisdictionView = new BranchJurisdictionView()
                {
                    BranchId = branchId,
                    JurisdictionId = branchView.JurisdictionId
                };
                branchInfo = this.agentOfDeductionRepository.SaveBranchUser(branchUserListView);
                branchInfo = this.agentOfDeductionRepository.SaveAgentOfDeductionBranch(agentOfDeductionView);
                branchInfo = this.agentOfDeductionRepository.SaveJurisdictionBranch(branchJurisdictionView);




            }



            return branchInfo;
        }

        /// <summary>
        /// Processes the delete branch information.
        /// </summary>
        /// <param name="BranchId">The branch identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteBranchInfo(int BranchId)
        {
            var viewModel = this.agentOfDeductionRepository.DeleteBranchInfo(BranchId);
            return viewModel;
        }

        /// <summary>
        /// Processes the delete branch information.
        /// </summary>
        /// <param name="BranchId">The branch identifier.</param>
        /// <returns></returns>
        public string ReactivateBranchInfo(int BranchId)
        {
            var viewModel = this.agentOfDeductionRepository.ReactivateBranchInfo(BranchId);
            return viewModel;
        }

        /// <summary>
        /// Gets the branch user ListView.
        /// </summary>
        /// <returns></returns>
        public IBranchListView GetBranchUserView()          //gets all the branches
        {

            var agentId = (int)session.GetSessionValue(SessionKey.AgentOfDeductionId);


            var users = this.accountRepository.GetUserRegistrationsById(agentId);

            var branchType = this.agentOfDeductionRepository.GetAgentOfdeductionBranch(agentId);     //list of branch


            return this.agentOfDeductionFactory.GetBranchUserListView(users, branchType);
        }



        /// <summary>
        /// Gets the branch by agent of deduction.
        /// </summary>
        /// <param name="agentId">The agent identifier.</param>
        /// <returns></returns>
        public IList<IBranch> GetBranchByAgentOfDeduction(int agentId)
        {
            return this.agentOfDeductionRepository.GetAgentOfdeductionBranch(agentId);
        }
        /// <summary>
        /// Gets the branch ListView.
        /// </summary>
        /// <returns></returns>
        public IBranchListView GetBranchListView( string infoMessage)          //gets all the branches
        {

            var agentId = (int)session.GetSessionValue(SessionKey.AgentOfDeductionId); ;


           

            var branchType = this.agentOfDeductionRepository.GetAgentOfdeductionBranch(agentId);     //list of branch

            var jurisdictionList = this.generalRepository.GetJurisdiction();
            return this.agentOfDeductionFactory.CreateBranchListView(branchType,jurisdictionList, infoMessage);
        }

        /// <summary>
        /// Gets the branch user ListView.
        /// </summary>
        /// <returns></returns>
        public IBranchListView GetBranchUserListView(int branchId, string infoMessage)   //gets users by branchId
        {

           int agentId= (int)session.GetSessionValue(SessionKey.AgentOfDeductionId);
            int userId=(int)session.GetSessionValue(SessionKey.UserId); 
            var branchUser = this.agentOfDeductionRepository.GetUserBranch(branchId);
            if (branchUser.Count > 0)
            {
                branchUser.RemoveAt(0);
            }
             
            var branchInfo = this.agentOfDeductionRepository.GetAgentOfdeductionBranch(agentId);
            branchInfo = branchInfo.Where(x => x.IsActive == true).ToList();
            var userList = this.accountRepository.GetUserRegistrationsById(userId);
            userList = userList.Where(x => x.IsActive == true).ToList();
            return this.agentOfDeductionFactory.GetBranchUserListView(userList, branchUser,branchInfo,infoMessage,branchId);
           
        }

        /// <summary>
        /// Saves the branch user information.
        /// </summary>
        /// <param name="branchUserView">The branch user view.</param>
        /// <returns></returns>
        public string SaveBranchUserInfo(IBranchListView branchUserView)
        {
            return this.agentOfDeductionRepository.SaveBranchUser(branchUserView);


        }
        /// <summary>
        /// Deletes the user branch.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        public string DeleteUserBranch(int userId, int branchId)
        {
            return this.agentOfDeductionRepository.DeleteUserBranch(branchId, userId);
        }
        /// <summary>
        /// Reactivates the user branch.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        public string ReactivateUserBranch(int userId, int branchId)
        {
            return this.agentOfDeductionRepository.ReactivateUserBranch(branchId, userId);
        }

        /// <summary>
        /// Gets the updated branch user ListView.
        /// </summary>
        /// <param name="branchUserListView">The branch user ListView.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IBranchListView GetUpdatedBranchUserListView(IBranchListView branchUserListView, string processingMessage)
        {

           var agentId = (int)session.GetSessionValue(SessionKey.AgentOfDeductionId); ;
            var userId = (int)session.GetSessionValue(SessionKey.UserId); 

            var users = this.accountRepository.GetUserRegistrationsById(userId);

            var branchType = this.agentOfDeductionRepository.GetAgentOfdeductionBranch(agentId);     //list of branch


            return this.agentOfDeductionFactory.GetUpdatedBranchUserListView(users, branchType, branchUserListView, processingMessage);
        }
        /// <summary>
        /// Checks the user branch exist.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        public bool CheckUserBranchExist(int userId, int branchId)
        {
            return this.agentOfDeductionRepository.CheckUserBranchExist(branchId, userId);
        }






        #endregion




        #region Tax Returns  


        #region AgentOfDeduction
        /// <summary>
        /// Gets the taxreturns view.
        /// </summary>
        /// <param name="infoMessage"></param>
        /// <returns></returns>
        public IBranchListView GetTaxreturnsView(string infoMessage)
        {
            var userId = (int)session.GetSessionValue(SessionKey.UserId);
            var branch = this.agentOfDeductionRepository.GetBranchByUserId(userId);
            branch = branch.Where(x => x.IsActive = true).ToList();
            var fileType = this.digitalFileRepository.GetTaxReturnFile();
            return this.agentOfDeductionFactory.CreateBranchView(branch,infoMessage,fileType);
        }



        /// <summary>
        /// Gets the tax returns ListView.
        /// </summary>
        /// <param name="taxReturnListView">The tax return ListView.</param>
        /// <returns></returns>
        public ITaxReturnListView GetTaxReturnsListView(ITaxReturnListView taxReturnListView)
        {


            var taxReturnInfo = new List<ITaxReturn>();
            var userId = (int)session.GetSessionValue(SessionKey.UserId);
            var branches = this.agentOfDeductionRepository.GetBranchByUserId(userId);


            var agentId = (int)session.GetSessionValue(SessionKey.AgentOfDeductionId);

            var taxReturn = this.agentOfDeductionRepository.GetTaxReturn(agentId);
            taxReturnInfo = taxReturn.Where(x => x.BranchId == taxReturnListView.BranchId && x.ContractDate >= taxReturnListView.StartDate && x.ContractDate <= taxReturnListView.EndDate&&x.IncomeTypeId==taxReturnListView.IncomeTypeId).OrderBy(x=>x.IncomeTypeName).ToList();

          

            return this.agentOfDeductionFactory.GetTaxReturnListView(taxReturnInfo, branches, taxReturnListView);


        }


        /// <summary>
        /// Processes the upload excel department.
        /// </summary>
        /// <param name="departmentExcelFile">The department excel file.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">departmentExcelFile</exception>
        public string ProcessUploadExcel(HttpPostedFileBase departmentExcelFile, int incomeTypeId, int branchId)
        {

            if (departmentExcelFile == null) throw new ArgumentNullException(nameof(departmentExcelFile));

            var result = string.Empty;
            var userId = (int)session.GetSessionValue(SessionKey.UserId);
            var jurisidiction = this.generalRepository.GetJurisdictionByBranchId(branchId);
            var agentOfdeduction = this.agentOfDeductionRepository.GetAgentOfdeductionBranchByranchId(branchId);
            var taxreturnCollection = this.agentOfDeductionRepository.ExcelUpload(departmentExcelFile);

            try
            {

                foreach (DataRow r in taxreturnCollection.Rows)
                {
                    var taxReturnView = new TaxReturnView()

                    {
                        BeneficiaryTin = r.ItemArray[8].ToString(),

                        BeneficiaryName = r.ItemArray[9].ToString(),
                        BVN = r.ItemArray[0].ToString(),
                        BeneficiaryAddress = r.ItemArray[1].ToString(),
                        InvoiceNo = r.ItemArray[2].ToString(),
                        ContractDate = r.ItemArray[3].ToString(),   //3
                        ContractDescription = r.ItemArray[4].ToString(),
                        ContractAmount = r.ItemArray[5].ToString(),
                        WHT_Rate = r.ItemArray[6].ToString(),
                        WHT_Amount = r.ItemArray[7].ToString(),
                        IncomeTypeId = incomeTypeId,
                        UserRegistrationId = userId,
                        BranchId = branchId,
                        IsActive = true,
                        DateCreated = DateTime.Now,
                        JurisdictionId = jurisidiction.JurisdictionId,
                        AgentOfDeductionId = agentOfdeduction.AgentOfDeductionId
                    };
                    result = this.agentOfDeductionRepository.SaveTaxReturnInfo(taxReturnView);




                }
            }
            catch
            {
                var ErrorFormat = "Invalid File Type";
                return ErrorFormat;

            }
          

            return result;
        }
        #endregion

        #region  TaxAuthority
        /// <summary>
        /// Gets the tax returns ListView.
        /// </summary>
        /// <param name="taxReturnListView">The tax return ListView.</param>
        /// <returns></returns>
        public ITaxReturnListView GetTaxAuthorityTaxReturnsView(ITaxReturnListView taxReturnListView)
        {


            var taxReturnInfo = new List<ITaxReturn>();
            var jurisdictionId = (int)session.GetSessionValue(SessionKey.JurisdictionId);
            var branches = this.agentOfDeductionRepository.GetBranchByJurisdiction(jurisdictionId);


           
            var taxReturn = this.agentOfDeductionRepository.GetTaxReturnByJurisdictionId(jurisdictionId);
            taxReturnInfo = taxReturn.Where(x => x.BranchId == taxReturnListView.BranchId && x.ContractDate >= taxReturnListView.StartDate && x.ContractDate <= taxReturnListView.EndDate).OrderBy(x=>x.IncomeTypeName).ToList();

         

            return this.agentOfDeductionFactory.GetTaxReturnListView(taxReturnInfo, branches, taxReturnListView);


        }

        #endregion

        #region SystemAdmin        
        /// <summary>
        /// Gets the system admin tax returns view.
        /// </summary>
        /// <param name="taxReturnListView">The tax return ListView.</param>
        /// <returns></returns>
        public ITaxReturnListView GetSystemAdminTaxReturnsView(ITaxReturnListView taxReturnListView)
        {
            var taxReturnInfo = new List<ITaxReturn>();
            var agentOfDeductionnfo = this.generalRepository.GetAgentOFDeduction();
            var jurisdictionInfo = this.generalRepository.GetJurisdiction();
            if (taxReturnListView.JurisdictionId>0) 
            {
                var taxReturnList = this.agentOfDeductionRepository.GetTaxReturnList();
            taxReturnInfo = taxReturnList.Where(x => x.JurisdictionId == taxReturnListView.JurisdictionId && x.ContractDate >= taxReturnListView.StartDate && x.ContractDate <= taxReturnListView.EndDate).OrderBy(x => x.IncomeTypeName).ToList();

            }
            else
            {

                var taxReturn = this.agentOfDeductionRepository.GetTaxReturnList();
                taxReturnInfo = taxReturn.Where(x => x.BranchId == taxReturnListView.BranchId && x.ContractDate >= taxReturnListView.StartDate && x.ContractDate <= taxReturnListView.EndDate).OrderBy(x => x.IncomeTypeName).ToList();

            }

            return this.agentOfDeductionFactory.GetTaxReturnView(taxReturnInfo, agentOfDeductionnfo, jurisdictionInfo, taxReturnListView);





           

        }

        #endregion

        #endregion

        #region Tax Report


        /// <summary>
        /// Gets the tax report view.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <returns></returns>
        public ITaxReportView GetTaxReportView(string infoMessage)
        {
            var fileType = this.digitalFileRepository.GetTaxReportFile();
            
            var incomeType = this.generalRepository.GetIncomeType().Where(x => x.IsActive == true).ToList();
            return this.agentOfDeductionFactory.CreateTaxReportView(infoMessage, incomeType, fileType);
        }

        /// <summary>
        /// Processes the upload excel.
        /// </summary>
        /// <param name="taxReportExcelFile">The tax report excel file.</param>
        /// <param name="taxReport">The tax report.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">taxReportExcelFile</exception>
        public string ProcessUploadExcel(HttpPostedFileBase taxReportExcelFile, ITaxReportView taxReport )
        {

            if (taxReportExcelFile == null) throw new ArgumentNullException(nameof(taxReportExcelFile));

            var result = string.Empty;
            var taxReportCollection = this.agentOfDeductionRepository.ExcelUpload(taxReportExcelFile);

            try
            {

                foreach (DataRow r in taxReportCollection.Rows)
                {
                    var taxReportView = new TaxReportView()

                    {
                        BeneficiaryTIN = r.ItemArray[0].ToString(),

                        BVN =  r.ItemArray[1].ToString(),
                       IncomeAmount = decimal.Parse(r.ItemArray[2].ToString()),
                       TaxAmount = decimal.Parse(r.ItemArray[3].ToString()),
                       Year=taxReport.Year,
                       IncomeTypeId=taxReport.IncomeTypeId

                    };
                    result = this.agentOfDeductionRepository.SaveTaxReportInfo(taxReportView);




                }
            }
            catch
            {
                var ErrorFormat = "Invalid File Type";
                return ErrorFormat;

            }


            return result;
        }


        


      

        

        /// <summary>
        /// Gets the tax report view.
        /// </summary>
        /// <param name="BVN">The BVN.</param>
        /// <param name="YearCreated">The year created.</param>
        /// <returns></returns>
        public ITaxReportView GetTaxReportView(string BVN, string YearCreated)
        {



          
            var taxReport = this.agentOfDeductionRepository.GetTaxReport(BVN, YearCreated);
            return this.agentOfDeductionFactory.GetTaxReportView(taxReport);


        }

#endregion
    }
}