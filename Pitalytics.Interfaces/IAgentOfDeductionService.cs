using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pitalytics.Interfaces
{
    public interface IAgentOfDeductionService
    {
        #region Branch Setup           

        /// <summary>
        /// Updates the branch information.
        /// </summary>
        /// <param name="branchView">The branch view.</param>
        /// <returns></returns>
        string UpdateBranchInfo(IBranchListView branchView);
        /// <summary>
        /// Gets the selected branch information.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        IBranchListView GetSelectedBranchInfo(int branchId);
       
        /// <summary>
        /// Gets the branch by agent of deduction.
        /// </summary>
        /// <param name="agentId">The agent identifier.</param>
        /// <returns></returns>
        IList<IBranch> GetBranchByAgentOfDeduction(int agentId);
        /// <summary>
        /// Gets the branch ListView.UpdateBranchInfo
        /// </summary>
        /// <returns></returns>
        IBranchListView GetBranchListView(string infoMessage);
        /// <summary>
        /// Reactivates the branch information.
        /// </summary>
        /// <param name="BranchId">The branch identifier.</param>
        /// <returns></returns>
        string ReactivateBranchInfo(int BranchId);
        /// <summary>
        /// Gets the branch user view.
        /// </summary>
        /// <returns></returns>
        IBranchListView GetBranchUserView();
        /// <summary>
        /// Gets the updated branch user ListView.
        /// </summary>
        /// <param name="branchUserListView">The branch user ListView.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IBranchListView GetUpdatedBranchUserListView(IBranchListView branchUserListView, string processingMessage);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        IBranchListView GetBranchUserListView(int branchId, string infoMessage);
        /// <summary>
        /// Checks the user branch exist.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        bool CheckUserBranchExist(int userId, int branchId);
        /// <summary>
        /// Deletes the user branch.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        string DeleteUserBranch(int userId, int branchId);
        /// <summary>
        /// Deletes the user branch.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        string ReactivateUserBranch(int userId, int branchId);
        /// <summary>
        /// Saves the branch user information.
        /// </summary>
        /// <param name="branchUserView">The branch user view.</param>
        /// <returns></returns>
        string SaveBranchUserInfo(IBranchListView branchUserView);
        /// <summary>
       /// <summary>
        /// Gets the branch view.
        /// </summary>
        /// <param name="branchView">The branch view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IBranchListView GetBranchView(IBranchListView branchView, string message);

        

        /// <summary>
        /// Processes the branch information.
        /// </summary>
        /// <param name="branchView">The branch view.</param>
        /// <returns></returns>
        string ProcessBranchInfo(IBranchListView branchView);

        /// <summary>
        /// Processes the delete branch information.
        /// </summary>
        /// <param name="BranchId">The branch identifier.</param>
        /// <returns></returns>
        string ProcessDeleteBranchInfo(int BranchId);

        #endregion


        #region Tax Returns            
        /// <summary>
        /// Gets the system admin tax returns view.
        /// </summary>
        /// <param name="taxReturnListView">The tax return ListView.</param>
        /// <returns></returns>
        ITaxReturnListView GetSystemAdminTaxReturnsView(ITaxReturnListView taxReturnListView);
        /// <summary>
        /// Gets the tax returns ListView.
        /// </summary>
        /// <param name="taxReturnListView">The tax return ListView.</param>
        /// <returns></returns>
        ITaxReturnListView GetTaxReturnsListView(ITaxReturnListView taxReturnListView);
        /// <summary>
        /// Processes the upload excel department.
        /// </summary>
        /// <param name="taxReturnExcelFile">The tax return excel file.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        string ProcessUploadExcel(HttpPostedFileBase taxReturnExcelFile,int incomeTypeId, int branchId);

        /// <summary>
        /// Gets the taxreturns view.
        /// </summary>
        /// <returns></returns>
        IBranchListView GetTaxreturnsView(string infoMessage);

        /// <summary>
        /// Gets the tax authority tax returns view.
        /// </summary>
        /// <param name="taxReturnListView">The tax return ListView.</param>
        /// <returns></returns>
        ITaxReturnListView GetTaxAuthorityTaxReturnsView(ITaxReturnListView taxReturnListView);

        /// <summary>
        /// Processes the upload excel.
        /// </summary>
        /// <param name="taxReportExcelFile">The tax report excel file.</param>
        /// <param name="taxReport">The tax report.</param>
        /// <returns></returns>
        string ProcessUploadExcel(HttpPostedFileBase taxReportExcelFile, ITaxReportView taxReport);

      

        /// <summary>
        /// Gets the tax report view.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <returns></returns>
        ITaxReportView GetTaxReportView(string infoMessage);


        /// <summary>
        /// Gets the tax report view.
        /// </summary>
        /// <param name="BVN">The BVN.</param>
        /// <param name="YearCreated">The year created.</param>
        /// <returns></returns>
        ITaxReportView GetTaxReportView(string BVN, string YearCreated);
        #endregion
    }
}