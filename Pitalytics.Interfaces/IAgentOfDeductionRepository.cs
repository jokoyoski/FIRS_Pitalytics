using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pitalytics.Interfaces
{
    public interface IAgentOfDeductionRepository
    {
        #region Tax             
        /// <summary>
        /// Gets the tax return list.
        /// </summary>
        /// <returns></returns>
        IList<ITaxReturn> GetTaxReturnList();
        /// <summary>
        /// Initializes a new instance of the <see cref="IAgentOfDeductionRepository" /> interface.
        /// </summary>
        /// <param name="taxReturnListView">The tax return ListView.</param>
        IList<ITaxReturn> GetTaxReturn(int agentId);
        /// <summary>
        /// Saves the tax return information.
        /// </summary>
        /// <param name="taxReturnView">The tax return view.</param>
        /// <returns></returns>
        string SaveTaxReturnInfo(ITaxReturnView taxReturnView);
        /// <summary>
        /// Excels the upload.
        /// </summary>
        /// <param name="excelFile">The excel file.</param>
        /// <returns></returns>
        DataTable ExcelUpload(HttpPostedFileBase excelFile);
        /// <summary>
        /// Gets the branch by jurisdiction.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        IList<IBranch> GetBranchByJurisdiction(int jurisdictionId);
        /// <summary>
        /// Gets the tax return by jurisdiction identifier.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        IList<ITaxReturn> GetTaxReturnByJurisdictionId(int jurisdictionId);

        /// <summary>
        /// Saves the tax report information.
        /// </summary>
        /// <param name="taxReportView">The tax report view.</param>
        /// <returns></returns>
        string SaveTaxReportInfo(ITaxReportView taxReportView);

        #endregion

        #region Branch Setup

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        IAgentOfDeductionBranch GetAgentOfdeductionBranchByranchId(int branchId);
        /// <summary>
        /// Gets the branch by user identifier.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        IList<IBranch> GetBranchByUserId(int branchId);
        /// <summary>
        /// Reactivates the branch information.
        /// </summary>
        /// <param name="BranchId">The branch identifier.</param>
        /// <returns></returns>
        string ReactivateBranchInfo(int BranchId);
        /// <summary>
        /// Saves the jurisdiction branch.
        /// </summary>
        /// <param name="branchJurisdiction">The branch jurisdiction.</param>
        /// <returns></returns>
        string SaveJurisdictionBranch(IBranchJurisdiction branchJurisdiction);
        /// <summary>
        /// Saves the agent of deduction branch.
        /// </summary>
        /// <param name="agentOfDeductionBranch">The agent of deduction branch.</param>
        /// <returns></returns>
        string SaveAgentOfDeductionBranch(IAgentOfDeductionBranch agentOfDeductionBranch);
        /// <summary>
        /// Gets the branch.
        /// </summary>
        /// <returns></returns>
        IList<IBranch> GetBranch();

        /// <summary>
        /// Gets the branch by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IBranch GetBranchById(int Id);

        /// <summary>
        /// Gets the branch description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IBranch GetBranchDescriptionByValue(string description);

        /// <summary>
        /// Edits the branch.
        /// </summary>
        /// <param name="branchView">The branch view.</param>
        /// <returns></returns>
        string EditBranch(IBranchListView branchView);

        /// <summary>
        /// Saves the branch information.
        /// </summary>
        /// <param name="branchView">The branch view.</param>
        /// <returns></returns>
        string SaveBranchInfo(IBranchListView branchView, out int branchId);

        /// <summary>
        /// Deletes the branch information.
        /// </summary>
        /// <param name="BranchId">The branch identifier.</param>
        /// <returns></returns>
        string DeleteBranchInfo(int BranchId);
        /// <summary>
        /// Gets the agent ofdeduction branch.
        /// </summary>
        /// <param name="agentOfDeductionId">The agent of deduction identifier.</param>
        /// <returns></returns>
        IList<IBranch> GetAgentOfdeductionBranch(int agentOfDeductionId);
        /// <summary>
        /// Checks the user branch exist.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        bool CheckUserBranchExist(int branchId, int userId);

        /// <summary>
        /// Deletes the user branch.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        string DeleteUserBranch(int branchId, int userId);
        /// <summary>
        /// Reactivates the user branch.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        string ReactivateUserBranch(int branchId, int userId);
        /// <summary>
        /// Gets the user branch.
        /// </summary>
        /// <returns></returns>
        IList<IBranch> GetUserBranch(int branchId);

        /// <summary>
        /// Saves the branch user.
        /// </summary>
        /// <param name="branchUserView">The branch user view.</param>
        /// <returns></returns>
        string SaveBranchUser(IBranchListView branchUserView);
        #endregion

        #region TaxReport 

        /// <summary>
        /// Gets the tax report.
        /// </summary>
        /// <param name="BVN">The BVN.</param>
        /// <param name="YearCreated">The date created.</param>
        /// <returns></returns>
        IList<ITaxReport> GetTaxReport(string BVN, string YearCreated);
      

        #endregion
    }
}
