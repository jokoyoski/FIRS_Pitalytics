using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
    public interface IGeneralFactory
    {



        #region AgentOfDeductions

        IAgentOfDeductionListView CreateAgentOfDeductionListView(int selectedId, string selectedDescription, IList<IAgentOfDeduction> agentOfDeductions, string message);

        #endregion

        #region IncomeType  

        /// <summary>
        /// Creates the edit income type jurisdiction view.
        /// </summary>
        /// <param name="incomeTypes">The income types.</param>
        /// <returns></returns>
        IIncomeTypeListView CreateEditIncomeTypeView(IIncomeType incomeTypes);
        /// <summary>
        /// Creates the income type jurisdiction view.
        /// </summary>
        /// <param name="jurisdictionIncomeTypes">The jurisdiction income types.</param>
        /// <returns></returns>
        IIncomeTypeListView CreateIncomeTypeJurisdictionView(IList<IJurisdictionIncomeType> jurisdictionIncomeTypes, string infoMessage, IList<IIncomeType> incomeTypes, IList<IJurisdiction> jurisdictions,int jurisdictionId);
        /// <summary>
        /// Creates the updated income type jurisdiction view.
        /// </summary>
        /// <param name="jurisdictions">The jurisdictions.</param>
        /// <param name="incomeTypes">The income types.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="incomeTypeListView">The income type ListView.</param>
        /// <returns></returns>
        IIncomeTypeListView CreateUpdatedIncomeTypeJurisdictionView(IList<IJurisdiction> jurisdictions, IList<IIncomeType> incomeTypes, string processingMessage, IIncomeTypeListView incomeTypeListView);
        /// <summary>
        /// Creates the income type jurisdiction view.
        /// </summary>
        /// <param name="jurisdictions">The jurisdictions.</param>
        /// <param name="incomeTypes">The income types.</param>
        /// <param name="jurisdictionIncomeTypes">The jurisdiction income types.</param>
        /// <returns></returns>
        IIncomeTypeListView CreateIncomeTypeJurisdictionView(IList<IJurisdiction> jurisdictions, IList<IIncomeType> incomeTypes);

        /// <summary>
        /// Creates the income type ListView.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="incomeTypeCollection">The income type collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IIncomeTypeListView CreateIncomeTypeListView(int selectedId, string selectedDescription, IList<IIncomeType> incomeTypeCollection, string message);

        /// Creates the income type view.
        /// </summary>
        /// <param name="incomeTypeView">The income type view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IIncomeTypeListView CreateIncomeTypeView(IIncomeTypeListView incomeTypeView, string processingMessage);


        #endregion

        #region Industry

        /// <summary>
        /// Creates the industry ListView.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="industryCollection">The industry collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IIndustryListView CreateIndustryListView(int selectedId, string selectedDescription, IList<IIndustry> industryCollection, string message);
        /// <summary>
        /// Creates the industry view.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <returns></returns>
        IIndustryListView CreateIndustryView(IIndustry industryView);
        /// <summary>
        /// Creates the industry view.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IIndustryListView CreateIndustryView(IIndustryListView industryView, string processingMessage);
        /// <summary>
        /// Creates the industry view.
        /// </summary>
        /// <returns></returns>
        IIndustryView CreateIndustryView();
        /// <summary>
        /// Gets the edit industry view.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <returns></returns>
        IIndustryView GetEditIndustryView(IIndustry industryView);

        #endregion


        #region Jurisdiction        
        /// <summary>
        /// Creates the jurisdiction view.
        /// </summary>
        /// <param name="jurisdictionView">The jurisdiction view.</param>
        /// <returns></returns>
        IJurisdictionListView CreateJurisdictionView(IJurisdiction jurisdictionListView);
        /// <summary>
        /// Creates the jurisdiction ListView.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="jurisdcitionCollection">The jurisdcition collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IJurisdictionListView CreateJurisdictionListView(int selectedId, string selectedDescription, IList<IJurisdiction> jurisdcitionCollection, string message);
        /// <summary>
        /// Creates the jurisdiction view.
        /// </summary>
        /// <param name="jurisdictionView">The jurisdiction view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IJurisdictionListView CreateJurisdictionView(IJurisdictionListView jurisdictionView, string processingMessage);
        /// <summary>
        /// Creates the jurisdiction view.
        /// </summary>
        /// <returns></returns>
        IJurisdictionView CreateJurisdictionView();
        #endregion



        /// <summary>
        /// Creates the tax authority ListView.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="taxAuthorityCollection">The tax authority collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        ITaxAuthorityListView CreateTaxAuthorityListView(int selectedId, string selectedDescription, IList<ITaxAuthority> taxAuthorityCollection, string message);




        #region Inland Revenue Setup        
        /// <summary>
        /// Creates the inland revenue ListView.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedInlandRevenueName">Name of the selected inland revenue.</param>
        /// <param name="inlandRevenueCollection">The inland revenue collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IInlandRevenueListView CreateInlandRevenueListView(int selectedId, string selectedInlandRevenueName, IList<IInlandRevenue> inlandRevenueCollection, string message);

        /// <summary>
        /// Creates the inland revenue view.
        /// </summary>
        /// <param name="inlandRevenueView">The inland revenue view.</param>
        /// <returns></returns>
        IInlandRevenueView CreateInlandRevenueView(IInlandRevenue inlandRevenueView);

        /// <summary>
        /// Creates the inland revenue view.
        /// </summary>
        /// <param name="inlandRevenueView">The inland revenue view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IInlandRevenueListView CreateInlandRevenueView(IInlandRevenueListView inlandRevenueView, string processingMessage);

        /// <summary>
        /// Creates the inland revenue view.
        /// </summary>
        /// <returns></returns>
        IInlandRevenueView CreateInlandRevenueView();

        /// <summary>
        /// Creates the edit inland revenue view.
        /// </summary>
        /// <param name="inlandRevenues">The inland revenues.</param>
        /// <returns></returns>
        IInlandRevenueListView CreateEditInlandRevenueView(IInlandRevenue inlandRevenues);

        #endregion

        #region Upload Excel 

        /// <summary>
        /// Creates the upload excel view.
        /// </summary>
        /// <param name="fileType">Type of the file.</param>
        /// <returns></returns>
        IDigitalFileView CreateUploadExcelView(IList<IFileType> fileType);
        /// <summary>
        /// Creates the upload excel view.
        /// </summary>
        /// <param name="digitalFileView">The digital file view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="fileType">Type of the file.</param>
        /// <returns></returns>
        IDigitalFileView CreateUploadExcelView(IDigitalFileView digitalFileView, string processingMessage, IList<IFileType> fileType);
       
        #endregion

    }


}



