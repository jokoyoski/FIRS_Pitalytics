using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
    public interface IAgentOfDeductionFactory
    {
        #region Branch Setup   

        /// <summary>
        /// Creates the branch view.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <returns></returns>
        IBranchListView CreateBranchView(IBranch branch);
       
        /// <summary>
        /// Gets the tax return view.
        /// </summary>
        /// <param name="taxReturns">The tax returns.</param>
        /// <param name="agentOfDeductions">The agent of deductions.</param>
        /// <param name="jurisdictions">The jurisdictions.</param>
        /// <param name="taxReturnListView">The tax return ListView.</param>
        /// <returns></returns>
        ITaxReturnListView GetTaxReturnView(IList<ITaxReturn> taxReturns, IList<IAgentOfDeduction> agentOfDeductions, IList<IJurisdiction> jurisdictions, ITaxReturnListView taxReturnListView);

        /// <summary>
        /// Gets the tax return ListView.
        /// </summary>
        /// <param name="taxReturns">The tax returns.</param>
        /// <param name="branches">The branches.</param>
        /// <param name="incomeTypes">The income types.</param>
        /// <returns></returns>
        ITaxReturnListView GetTaxReturnListView(IList<ITaxReturn> taxReturns, IList<IBranch> branches,ITaxReturnListView taxReturnListView);
        /// <summary>
        /// Creates the branch view.
        /// </summary>
        /// <param name="branches">The branches.</param>
        /// <returns></returns>
        IBranchListView CreateBranchView(IList<IBranch> branches,string infoMessage,IDigitalFile fileType);

        /// <summary>
        /// Creates the branch ListView.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="branchCollection">The branch collection.</param>
        /// <param name="message">The message.</param>
        IBranchListView CreateBranchListView(IList<IBranch> branchCollection,IList<IJurisdiction>jurisdictions,string infoMessage);

        /// <summary>
        /// Creates the tax report view.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="incomeTypes">The income types.</param>
        /// <param name="fileType">Type of the file.</param>
        /// <returns></returns>
        ITaxReportView CreateTaxReportView(string infoMessage, IList<IIncomeType> incomeTypes, IDigitalFile fileType);



        /// <summary>
        /// Creates the branch view.
        /// </summary>
        /// <param name="branchView">The branch view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IBranchListView CreateBranchView(IBranchListView branchView, string processingMessage, IList<IJurisdiction> jurisdictions);

        /// <summary>
        /// Creates the branch view.
        /// </summary>
        /// <returns></returns>
        IBranchListView CreateBranchView(IList<IJurisdiction> jurisdictions);
        /// <summary>
        /// Gets the updated branch user ListView.
        /// </summary>
        /// <param name="userRegistrations">The user registrations.</param>
        /// <param name="branches">The branches.</param>
        /// <param name="branchUserListView">The branch user ListView.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IBranchListView GetUpdatedBranchUserListView(IList<IUserRegistration> userRegistrations, IList<IBranch> branches, IBranchListView branchUserListView, string processingMessage);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRegistrations"></param>
        /// <param name="branches"></param>
        /// <param name="branchUserListView"></param>
        /// <returns></returns>
        IBranchListView GetBranchUserListView(IList<IUserRegistration> userRegistrations, IList<IBranch> branches,IList<IBranch>branchList, string infoMessage,int branchId);
        /// <summary>
        /// Gets the branch user ListView.
        /// </summary>
        /// <param name="branches">The branches.</param>
        /// <returns></returns>
        IBranchListView GetBranchUserListView(IList<IBranch> branches);

        /// <summary>
        /// Gets the branch user ListView.
        /// </summary>
        /// <param name="userRegistrations">The user registrations.</param>
        /// <param name="branches">The branches.</param>
        /// <returns></returns>
        IBranchListView GetBranchUserListView(IList<IUserRegistration> userRegistrations, IList<IBranch> branches);
        #endregion        
        /// <summary>
        /// Gets the tax report view.
        /// </summary>
        /// <param name="taxReports">The tax reports.</param>
        /// <returns></returns>
        ITaxReportView GetTaxReportView(IList<ITaxReport> taxReports);

    }
}
