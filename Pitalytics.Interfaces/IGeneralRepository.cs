using Pitalytics.Interfaces;
using System.Collections.Generic;


namespace Pitalytics.Interfaces
{
    public interface IGeneralRepository
    {



        #region AgentOfDeduction                  
        /// <summary>
        /// Activates the agent of deduction.
        /// </summary>
        /// <param name="agentOfDeductionId">The agent of deduction identifier.</param>
        /// <returns></returns>
        string ActivateAgentOfDeduction(int agentOfDeductionId);
        /// <summary>
        /// Deactivates the agent of deduction.
        /// </summary>
        /// <param name="agentOfDeductionId">The agent of deduction identifier.</param>
        /// <returns></returns>
        string DeactivateAgentOfDeduction(int agentOfDeductionId);
        /// <summary>
        /// Gets the agent of deduction.
        /// </summary>
        /// <returns></returns>
        IList<IAgentOfDeduction> GetAgentOFDeduction();
        #endregion

        #region IncomeType             
        /// <summary>
        /// Gets the income type by branch identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IEnumerable<IIncomeType> GetIncomeTypeByBranchId(int Id);
        /// <summary>
        /// Gets the income type jurisdiction.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <returns></returns>
        IJurisdictionIncomeType GetIncomeTypeJurisdiction(int jurisdictionId, int incomeTypeId);
        /// <summary>
        /// Saves the income type jurisdiction information.
        /// </summary>
        /// <param name="incomeTypeListView">The income type ListView.</param>
        /// <returns></returns>
        string SaveIncomeTypeJurisdictionInfo(IIncomeTypeListView incomeTypeListView);

        /// <summary>
        /// Deletes the income type by jurisdiction.
        /// </summary>
        /// <param name="jursdictionId">The jursdiction identifier.</param>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <returns></returns>
        string DeleteIncomeTypeByJurisdiction(int jursdictionId, int incomeTypeId);
        /// <summary>
        /// Gets the type of the income.
        /// </summary>
        /// <returns></returns>
        IList<IIncomeType> GetIncomeType();

        /// <summary>
        /// Gets the income type by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IIncomeType GetIncomeTypeById(int Id);

        /// <summary>
        /// Edits the type of the income.
        /// </summary>
        /// <param name="incomeTypeView">The income type view.</param>
        /// <returns></returns>
        string EditIncomeType(IIncomeTypeListView incomeTypeView);

        /// <summary>
        /// Saves the income type information.
        /// </summary>
        /// <param name="incomeTypeView">The income type view.</param>
        /// <returns></returns>
        string SaveIncomeTypeInfo(IIncomeTypeListView incomeTypeView);

        /// <summary>
        /// Gets the income type description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IIncomeType GetIncomeTypeDescriptionByValue(string description);

        /// <summary>
        /// Deletes the income type information.
        /// </summary>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <returns></returns>
        string DeleteIncomeTypeInfo(int incomeTypeId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string ReactivateIncomeType(int Id);
        #endregion

        #region Juridiction   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string ReactivateJurisidcition(int Id);
        /// <summary>
        /// Gets the income type by jurisdiction.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        IEnumerable<IJurisdictionIncomeType> GetIncomeTypeByJurisdiction(int jurisdictionId);
        /// <summary>
        /// Gets the jurisdiction.
        /// </summary>
        /// <returns></returns>
        IList<IJurisdiction> GetJurisdiction();
        /// <summary>
        /// Gets the jurisdiction by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IJurisdiction GetJurisdictionById(int Id);
        /// <summary>
        /// Gets the jurisdiction description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IJurisdiction GetJurisdictionDescriptionByValue(string description);
        /// <summary>
        /// Edits the jurisdiction.
        /// </summary>
        /// <param name="jurisdictionView">The jurisdiction view.</param>
        /// <returns></returns>
        string EditJurisdiction(IJurisdictionListView jurisdictionView);
        /// <summary>
        /// Saves the jurisdiction information.
        /// </summary>
        /// <param name="jurisdictionView">The jurisdiction view.</param>
        /// <returns></returns>
        string SaveJurisdictionInfo(IJurisdictionListView jurisdictionView);
        /// <summary>
        /// Deletes the jurisdiction information.
        /// </summary>
        /// <param name="JurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        string DeleteJurisdictionInfo(int JurisdictionId);


        /// <summary>
        /// Gets the jurisdiction by branch identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IBranchJurisdiction GetJurisdictionByBranchId(int Id);
        #endregion


        #region  TaxAuthority           
        /// <summary>
        /// Gets the tax authority.
        /// </summary>
        /// <returns></returns>
        IList<ITaxAuthority> GetTaxAuthority();

        /// <summary>
        /// Initializes a new instance of the <see cref="IGeneralRepository" /> interface.
        /// </summary>
        /// <param name="taxAuthorityId">The tax authority identifier.</param>
      string  ActivateTaxAuthority(int taxAuthorityId);


        /// <summary>
        /// Dectivates the tax authority.
        /// </summary>
        /// <param name="taxAuthorityId">The tax authority identifier.</param>
        /// <returns></returns>
        string DeActivateTaxAuthority(int taxAuthorityId);
        #endregion

        #region Industry
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string ReactivateIndustry(int Id);
        /// <summary>
        /// Gets the industry.
        /// </summary>
        /// <returns></returns>
        IList<IIndustry> GetIndustry();
        /// <summary>
        /// Gets the industry by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IIndustry GetIndustryById(int Id);
        /// <summary>
        /// Gets the industry description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IIndustry GetIndustryDescriptionByValue(string description);
        /// <summary>
        /// Edits the industry.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <returns></returns>
        string EditIndustry(IIndustryListView industryView);
        /// <summary>
        /// Saves the industry information.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <returns></returns>
        string SaveIndustryInfo(IIndustryListView industryView);
        /// <summary>
        /// Deletes the industry information.
        /// </summary>
        /// <param name="IndustryId">The industry identifier.</param>
        /// <returns></returns>
        string DeleteIndustryInfo(int IndustryId);

        #endregion



        #region        

        #endregion

        #region Inland Revenue Setup      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string ReactivateInlandRevenue(int Id);
        /// <summary>
        /// Gets the inland revenue.
        /// </summary>
        /// <returns></returns>
        IList<IInlandRevenue> GetInlandRevenue();
        /// <summary>
        /// Gets the inland revenue by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IInlandRevenue GetInlandRevenueById(int Id);

        /// <summary>
        /// Gets the inland revenue name by value.
        /// </summary>
        /// <param name="inlandRevenueName">Name of the inland revenue.</param>
        /// <returns></returns>
        IInlandRevenue GetInlandRevenueNameByValue(string inlandRevenueName);

        /// <summary>
        /// Edits the inland revenue.
        /// </summary>
        /// <param name="inlandRevenueView">The inland revenue view.</param>
        /// <returns></returns>
        string EditInlandRevenue(IInlandRevenueListView inlandRevenueView);

        /// <summary>
        /// Saves the inland revenue information.
        /// </summary>
        /// <param name="inlandRevenueView">The inland revenue view.</param>
        /// <returns></returns>
        string SaveInlandRevenueInfo(IInlandRevenueListView inlandRevenueView);

        /// <summary>
        /// Deletes the inland revenue information.
        /// </summary>
        /// <param name="InlandRevenueId">The inland revenue identifier.</param>
        /// <returns></returns>
        string DeleteInlandRevenueInfo(int InlandRevenueId);
        #endregion


        #region FileType        
        /// <summary>
        /// Gets the type of the file.
        /// </summary>
        /// <returns></returns>
        IList<IFileType> GetFileType();
        #endregion
    }
}
