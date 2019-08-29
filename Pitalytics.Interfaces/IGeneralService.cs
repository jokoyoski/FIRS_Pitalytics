
using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pitalytics.Interfaces
{
    public interface IGeneralService
    {



        #region       AgentOfDeduction 
        /// <summary>
        /// Gets the agent of deduction view model.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IAgentOfDeductionListView GetAgentOfDeductionViewModel(int selectedId, string selectedDescription, string message);
        #endregion AgentOfDeduction        

        /// <summary>
        /// Gets the income type by branch identifier.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        IEnumerable<IIncomeType> GetIncomeTypeByBranchId(int branchId);
        /// <summary>
        /// Deactivates the agent of deduction.
        /// </summary>
        /// <param name="agentOfDeductionId">The agent of deduction identifier.</param>
        /// <returns></returns>
        string DeactivateAgentOfDeduction(int agentOfDeductionId);
        /// <summary>
        /// Activates the agent of deduction.
        /// </summary>
        /// <param name="agentOfDeductionId">The agent of deduction identifier.</param>
        /// <returns></returns>
        string ActivateAgentOfDeduction(int agentOfDeductionId);

        #region IncomeType           
        /// <summary>
        /// Gets the type of the selected income.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <param name="infoMessage">The information message.</param>
        /// <returns></returns>
        IIncomeTypeListView GetSelectedIncomeType(int jurisdictionId, string infoMessage);
        /// <summary>
        /// Creates the updated income type jurisdiction view.
        /// </summary>
        /// <param name="incomeTypeListView">The income type ListView.</param>
        /// <param name="infoMessage">The information message.</param>
        /// <returns></returns>
        IIncomeTypeListView CreateUpdatedIncomeTypeJurisdictionView(IIncomeTypeListView incomeTypeListView, string infoMessage);
        /// <summary>
        /// Gets the income type ListView.
        /// </summary>
        /// <returns></returns>
        IIncomeTypeListView GetIncomeTypeListView();
        /// <summary>
        /// Processes the income type jurisdiction information.
        /// </summary>
        /// <param name="incomeTypeListView">The income type ListView.</param>
        /// <returns></returns>
        string ProcessIncomeTypeJurisdictionInfo(IIncomeTypeListView incomeTypeListView);
        /// <summary>
        /// Processes the delete income type jurisdiction information.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <returns></returns>
        string ProcessDeleteIncomeTypeJurisdictionInfo(int jurisdictionId, int incomeTypeId);
        /// <summary>
        /// Gets the type of the jurisdiction income.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        IIncomeTypeListView GetJurisdictionIncomeType(int jurisdictionId, string infoMessage);
        /// <summary>
        /// Gets the income type view model.
        /// </summary>
        /// <param name="selectedIncomeTypeId">The selected income type identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IIncomeTypeListView GetIncomeTypeViewModel(int selectedIncomeTypeId, string selectedDescription, string message);


        /// <summary>
        /// Gets the income type view.
        /// </summary>
        /// <param name="incomeTypeView">The income type view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IIncomeTypeListView GetIncomeTypeView(IIncomeTypeListView incomeTypeView, string message);

        /// <summary>
        /// Updates the income type information.
        /// </summary>
        /// <param name="incomeTypeView">The income type view.</param>
        /// <returns></returns>
        string UpdateIncomeTypeInfo(IIncomeTypeListView incomeTypeView);

        /// <summary>
        /// Processes the income type information.
        /// </summary>
        /// <param name="incomeTypeView">The income type view.</param>
        /// <returns></returns>
        string ProcessIncomeTypeInfo(IIncomeTypeListView incomeTypeView);
        /// <summary>
        /// Processes the delete income type information.
        /// </summary>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <returns></returns>
        string ProcessDeleteIncomeTypeInfo(int incomeTypeId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string ReactivateIncomeType(int Id);

        #endregion



        #region Industry

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string ReactivateIndustry(int Id);
        /// <summary>
        /// Gets the selected color by information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IIndustryListView GetSelectedIndustryByInfo(int Id);
        /// <summary>
        /// Gets the industry ListView model.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IIndustryListView GetIndustryListViewModel(int selectedId, string selectedDescription, string message);
        /// <summary>
        /// Gets the industry view.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IIndustryListView GetIndustryView(IIndustryListView industryView, string message);
        /// <summary>
        /// Updates the industry information.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <returns></returns>
        string UpdateIndustryInfo(IIndustryListView industryView);
        /// <summary>
        /// Gets the industry view.
        /// </summary>
        /// <returns></returns>
        IIndustryView GetIndustryView();
        /// <summary>
        /// Processes the industry information.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <returns></returns>
        string ProcessIndustryInfo(IIndustryListView industryView);
        /// <summary>
        /// Processes the delete industry information.
        /// </summary>
        /// <param name="IndustryId">The industry identifier.</param>
        /// <returns></returns>
        string ProcessDeleteIndustryInfo(int IndustryId);

        #endregion


        #region jurisdiction
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string ReactivateJurisidcition(int Id);
        /// <summary>
        /// Gets the jurisdiction ListView model.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IJurisdictionListView GetJurisdictionListViewModel(int selectedId, string selectedDescription, string message);
        /// <summary>
        /// Gets the selected jurisdiction by information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IJurisdictionListView GetSelectedJurisdictionByInfo(int Id);
        /// <summary>
        /// Gets the jurisdiction view.
        /// </summary>
        /// <param name="jurisdictionView">The jurisdiction view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IJurisdictionListView GetJurisdictionView(IJurisdictionListView jurisdictionView, string message);
        /// <summary>
        /// Updates the jurisdiction information.
        /// </summary>
        /// <param name="jurisdictionView">The jurisdiction view.</param>
        /// <returns></returns>
        string UpdateJurisdictionInfo(IJurisdictionListView jurisdictionView);
        /// <summary>
        /// Gets the jurisdiction view.
        /// </summary>
        /// <returns></returns>
        IJurisdictionView GetJurisdictionView();
        /// <summary>
        /// Processes the color information.
        /// </summary>
        /// <param name="jurisdictionView">The jurisdiction view.</param>
        /// <returns></returns>
        string ProcessJurisdictionInfo(IJurisdictionListView jurisdictionView);
        /// <summary>
        /// Processes the delete jurisdiction information.
        /// </summary>
        /// <param name="JurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        string ProcessDeleteJurisdictionInfo(int JurisdictionId);
        #endregion

        /// Gets the inland revenue ListView model.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedInlandRevenueName">Name of the selected inland revenue.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>

        #region Inland Revenue Setup  

        ///  Reactivate Inland Revenue
        ///
        string ReactivateInlandRevenue(int Id); 
        /// <summary>
        /// Gets the inland revenue ListView model.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedInlandRevenueName">Name of the selected inland revenue.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IInlandRevenueListView GetInlandRevenueListViewModel(int selectedId, string selectedInlandRevenueName, string message);

        /// <summary>
        /// Gets the selected inland revenue by information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IInlandRevenueView GetSelectedInlandRevenueByInfo(int Id);

        /// <summary>
        /// Gets the inland revenue view.
        /// </summary>
        /// <param name="inlandRevenueView">The inland revenue view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IInlandRevenueListView GetInlandRevenueView(IInlandRevenueListView inlandRevenueView, string message);

        /// <summary>
        /// Processes the inland revenue information.
        /// </summary>
        /// <param name="inlandRevenueView">The inland revenue view.</param>
        /// <returns></returns>
        string ProcessInlandRevenueInfo(IInlandRevenueListView inlandRevenueView);

        /// <summary>
        /// Updates the inland revenue information.
        /// </summary>
        /// <param name="inlandRevenueView">The inland revenue view.</param>
        /// <returns></returns>
        string UpdateInlandRevenueInfo(IInlandRevenueListView inlandRevenueView);

        /// <summary>
        /// Gets the inland revenue view.
        /// </summary>
        /// <returns></returns>
        IInlandRevenueView GetInlandRevenueView();

        /// <summary>
        /// Gets the selected inland revenue.
        /// </summary>
        /// <param name="inlandRevenueId">The inland revenue identifier.</param>
        /// <param name="infoMessage">The information message.</param>
        /// <returns></returns>
        IInlandRevenueListView GetSelectedInlandRevenue(int inlandRevenueId, string infoMessage);

        /// <summary>
        /// Processes the delete inland revenue information.
        /// </summary>
        /// <param name="InlandRevenueId">The inland revenue identifier.</param>
        /// <returns></returns>
        string ProcessDeleteInlandRevenueInfo(int InlandRevenueId);

        #endregion


        #region TaxAuthority         
        /// <summary>
        /// Gets the tax authority ListView model.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITaxAuthorityListView GetTaxAuthorityListViewModel(int selectedId, string selectedDescription, string message);
        /// <summary>
        /// Activates the tax autority.
        /// </summary>
        /// <param name="taxAuthorityId">The tax authority identifier.</param>
        /// <returns></returns>
        string ActivateTaxAutority(int taxAuthorityId);

        /// <summary>
        /// Des the activate tax authority.
        /// </summary>
        /// <param name="taxAuthorityId">The tax authority identifier.</param>
        /// <returns></returns>
        string DeActivateTaxAuthority(int taxAuthorityId);
        #endregion

        #region Upload Excel               
        /// <summary>
        /// Processes the upload excel main information.
        /// </summary>
        /// <param name="excelSheet">The excel sheet.</param>
        /// <param name="digitalFileView">The digital file view.</param>
        /// <returns></returns>
        string ProcessUploadExcelMainInfo(HttpPostedFileBase excelSheet, IDigitalFileView digitalFileView);

        /// <summary>
        /// Gets the upload excel view.
        /// </summary>
        /// <returns></returns>
        IDigitalFileView GetUploadExcelView();
        /// <summary>
        /// Gets the upload excel view.
        /// </summary>
        /// <param name="digitalFileView">The digital file view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDigitalFileView GetUploadExcelView(IDigitalFileView digitalFileView, string processingMessage);

        /// <summary>
        /// Gets the excel file for download.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IDigitalFile GetExcelFileForDownload(int id);
        #endregion
    }
}