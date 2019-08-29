using AA.Infrastructure.Interfaces;
using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Domain.Resources;
using Pitalytics.Domain.Models;
using Pitalytics.Interfaces.ValueTypes;
using System.Web;

namespace Pitalytics.Domain.Services
{
    public class GeneralService : IGeneralService
    {

        private readonly IGeneralFactory generalFactory;

        private readonly IGeneralRepository generalRepository;
        private readonly IDigitalFileServices digitalFileServices;

        private readonly IDigitalFileRepository digitalFileRepository;
        private readonly IAccountRepository accountRepository;
        private readonly ISessionStateService session;

        public GeneralService(IGeneralFactory generalFactory, IDigitalFileServices digitalFileServices, IDigitalFileRepository digitalFileRepository, IGeneralRepository generalRepository, IAccountRepository accountRepository, ISessionStateService session)
        {

            this.generalFactory = generalFactory;
            this.generalRepository = generalRepository;
            this.accountRepository = accountRepository;
            this.digitalFileServices = digitalFileServices;
            this.digitalFileRepository = digitalFileRepository;

            this.session = session;
        }

        #region IncomeType

        /// <summary>
        /// Gets the income type view model.
        /// </summary>
        /// <param name="selectedIncomeTypeId">The selected income type identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IIncomeTypeListView GetIncomeTypeViewModel(int selectedIncomeTypeId, string selectedDescription, string message)
        {
            var incomeTypeCollection = this.generalRepository.GetIncomeType().ToList();
           
            return this.generalFactory.CreateIncomeTypeListView(selectedIncomeTypeId, selectedDescription, incomeTypeCollection, message);
        }


        /// <summary>
        /// Gets the income type view.
        /// </summary>
        /// <param name="incomeTypeView">The income type view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IIncomeTypeListView GetIncomeTypeView(IIncomeTypeListView incomeTypeView, string message)
        {
            return this.generalFactory.CreateIncomeTypeView(incomeTypeView, message);
        }




        /// <summary>
        /// Gets the income type ListView.
        /// </summary>
        /// <returns></returns>
        public IIncomeTypeListView GetIncomeTypeListView()
        {
            var incomeTypes = this.generalRepository.GetIncomeType();
            incomeTypes = incomeTypes.Where(x => x.IsActive == true).ToList();
            var jurisdiction = this.generalRepository.GetJurisdiction();
            jurisdiction = jurisdiction.Where(x => x.IsActive == true).ToList();
            return this.generalFactory.CreateIncomeTypeJurisdictionView(jurisdiction, incomeTypes);
        }




        /// <summary>
        /// Creates the updated income type jurisdiction view.
        /// </summary>
        /// <param name="incomeTypeListView">The income type ListView.</param>
        /// <param name="infoMessage">The information message.</param>
        /// <returns></returns>
        public IIncomeTypeListView CreateUpdatedIncomeTypeJurisdictionView(IIncomeTypeListView incomeTypeListView, string infoMessage)
        {
            var incomeTypes = this.generalRepository.GetIncomeType();
            incomeTypes = incomeTypes.Where(x => x.IsActive == true).ToList();
            var jurisdiction = this.generalRepository.GetJurisdiction();
            jurisdiction = jurisdiction.Where(x => x.IsActive == true).ToList();

            return this.generalFactory.CreateUpdatedIncomeTypeJurisdictionView(jurisdiction, incomeTypes, infoMessage, incomeTypeListView);
        }



        /// <summary>
        /// Gets the type of the jurisdiction income.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <returns></returns>
        public IIncomeTypeListView GetJurisdictionIncomeType(int jurisdictionId, string infoMessage)
        {
            var incomeTypes = this.generalRepository.GetIncomeType();
            incomeTypes = incomeTypes.Where(x => x.IsActive == true).ToList();
            var jurisdiction = this.generalRepository.GetJurisdiction();
            jurisdiction = jurisdiction.Where(x => x.IsActive == true).ToList();
            var jurisdictionIncomeType = this.generalRepository.GetIncomeTypeByJurisdiction(jurisdictionId).ToList();

            return this.generalFactory.CreateIncomeTypeJurisdictionView(jurisdictionIncomeType, infoMessage, incomeTypes, jurisdiction,jurisdictionId);
        }

        /// <summary>
        /// Gets the type of the selected income.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <param name="infoMessage">The information message.</param>
        /// <returns></returns>
        public IIncomeTypeListView GetSelectedIncomeType(int incomeTypeId, string infoMessage)
        {
            var incomeType = this.generalRepository.GetIncomeTypeById(incomeTypeId);

            return this.generalFactory.CreateEditIncomeTypeView(incomeType);
        }


        /// <summary>
        /// Updates the income type information.
        /// </summary>
        /// <param name="incomeTypeView">The income type view.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">incomeTypeView</exception>
        public string UpdateIncomeTypeInfo(IIncomeTypeListView incomeTypeView)
        {
            if (incomeTypeView == null)
            {
                throw new ArgumentNullException(nameof(incomeTypeView));
            }

            var processingMessage = string.Empty;

            var dataValue = this.generalRepository.GetIncomeTypeDescriptionByValue(incomeTypeView.IncomeTypeName);
            var isRecordExist = (dataValue == null) ? false : true;

            if (isRecordExist)
            {
                processingMessage = Messages.IncomeTypeExist;
                return processingMessage;
            }

            var editIncomeType = this.generalRepository.EditIncomeType(incomeTypeView);

            return editIncomeType;
        }

        /// <summary>
        /// Processes the income type information.
        /// </summary>
        /// <param name="incomeTypeView">The income type view.</param>
        /// <returns></returns>
        public string ProcessIncomeTypeInfo(IIncomeTypeListView incomeTypeView)
        {
            var processingMessages = string.Empty;

            var dataValue = this.generalRepository.GetIncomeTypeDescriptionByValue(incomeTypeView.IncomeTypeName);

            var isRecordExist = (dataValue == null) ? false : true;

            if (isRecordExist)
            {
                processingMessages = Messages.IncomeTypeExist;
                return processingMessages;
            }

            var incomeTypeInfo = this.generalRepository.SaveIncomeTypeInfo(incomeTypeView);

            return incomeTypeInfo;
        }






        /// <summary>
        /// Processes the income type jurisdiction information.
        /// </summary>
        /// <param name="incomeTypeListView">The income type ListView.</param>
        /// <returns></returns>
        public string ProcessIncomeTypeJurisdictionInfo(IIncomeTypeListView incomeTypeListView)
        {
            var processingMessages = string.Empty;

            var dataValue = this.generalRepository.GetIncomeTypeJurisdiction(incomeTypeListView.JurisdictionId, incomeTypeListView.IncomeTypeId);

            var isRecordExist = (dataValue == null) ? false : true;

            if (isRecordExist)
            {
                processingMessages = Messages.IncomeTypeJurisdictionExist;
                return processingMessages;
            }

            var incomeTypeInfo = this.generalRepository.SaveIncomeTypeJurisdictionInfo(incomeTypeListView);

            return incomeTypeInfo;
        }

        /// <summary>
        /// Gets the income type by branch identifier.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <returns></returns>
        public IEnumerable<IIncomeType> GetIncomeTypeByBranchId(int branchId)
        {

            return this.generalRepository.GetIncomeTypeByBranchId(branchId);
        }

        /// <summary>
        /// Processes the delete income type information.
        /// </summary>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteIncomeTypeInfo(int incomeTypeId)
        {
            var incomeTypeEditing = this.generalRepository.DeleteIncomeTypeInfo(incomeTypeId);
            return incomeTypeEditing;
        }



        /// <summary>
        /// Processes the delete income type jurisdiction information.
        /// </summary>
        /// <param name="jurisdictionId">The jurisdiction identifier.</param>
        /// <param name="incomeTypeId">The income type identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteIncomeTypeJurisdictionInfo(int jurisdictionId, int incomeTypeId)
        {
            var incomeTypeEditing = this.generalRepository.DeleteIncomeTypeByJurisdiction(jurisdictionId, incomeTypeId);
            return incomeTypeEditing;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string ReactivateIncomeType(int Id)
        {
            return this.generalRepository.ReactivateIncomeType(Id); 
        }


        #endregion





        #region Jurisdiction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string ReactivateJurisidcition(int Id)
        {
            return this.generalRepository.ReactivateJurisidcition(Id);
        }

        /// <summary>
        /// Gets the jurisdiction ListView model.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IJurisdictionListView GetJurisdictionListViewModel(int selectedId, string selectedDescription, string message)
        {
            var jurisdictionCollection = this.generalRepository.GetJurisdiction().ToList();
            return this.generalFactory.CreateJurisdictionListView(selectedId, selectedDescription, jurisdictionCollection, message);
        }

        /// <summary>
        /// Gets the selected jurisdiction by information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IJurisdictionListView GetSelectedJurisdictionByInfo(int Id)
        {
            var jurisdictionById = this.generalRepository.GetJurisdictionById(Id);
            return this.generalFactory.CreateJurisdictionView(jurisdictionById);
        }

        /// <summary>
        /// Gets the jurisdiction view.
        /// </summary>
        /// <param name="jurisdictionView">The jurisdiction view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IJurisdictionListView GetJurisdictionView(IJurisdictionListView jurisdictionView, string message)
        {
            return this.generalFactory.CreateJurisdictionView(jurisdictionView, message);
        }

        /// <summary>
        /// Updates the jurisdiction information.
        /// </summary>
        /// <param name="jurisdictionView">The jurisdiction view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">jurisdictionView</exception>
        public string UpdateJurisdictionInfo(IJurisdictionListView jurisdictionView)
        {
            if (jurisdictionView == null)
            {
                throw new ArgumentNullException(nameof(jurisdictionView));
            }


            var processingMessages = string.Empty;

            var dataValue = this.generalRepository.GetJurisdictionDescriptionByValue(jurisdictionView.JurisdictionName);
            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.JurisdictionExist;
                return processingMessages;
            }
            var editJurisdiction = this.generalRepository.EditJurisdiction(jurisdictionView);


            return editJurisdiction;

        }
        /// <summary>
        /// Gets the jurisdiction view.
        /// </summary>
        /// <returns></returns>
        public IJurisdictionView GetJurisdictionView()
        {
            return this.generalFactory.CreateJurisdictionView();
        }
        /// <summary>
        /// Processes the color information.
        /// </summary>
        /// <param name="jurisdictionView">The jurisdiction view.</param>
        /// <returns></returns>
        public string ProcessJurisdictionInfo(IJurisdictionListView jurisdictionView)
        {

            var processingMessages = string.Empty;

            var dataValue = this.generalRepository.GetJurisdictionDescriptionByValue(jurisdictionView.JurisdictionName);

            if (dataValue != null)
            {
                processingMessages = Messages.JurisdictionExist;
                return processingMessages;
            }

            processingMessages = this.generalRepository.SaveJurisdictionInfo(jurisdictionView);

            return processingMessages;
        }

        public string ProcessDeleteJurisdictionInfo(int JurisdictionId)
        {
            var jurisdictionIdEdting = this.generalRepository.DeleteJurisdictionInfo(JurisdictionId);
            return jurisdictionIdEdting;
        }

        #endregion


        #region Industry    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string ReactivateIndustry(int Id)
        {
            return this.generalRepository.ReactivateIndustry(Id); 
        }
        /// <summary>
        /// Gets the industry ListView model.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IIndustryListView GetIndustryListViewModel(int selectedId, string selectedDescription, string message)
        {
            var industryCollection = this.generalRepository.GetIndustry().ToList();
            return this.generalFactory.CreateIndustryListView(selectedId, selectedDescription, industryCollection, message);
        }
        /// <summary>
        /// Gets the selected color by information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IIndustryListView GetSelectedIndustryByInfo(int Id)
        {
            var industryById = this.generalRepository.GetIndustryById(Id);
            return this.generalFactory.CreateIndustryView(industryById);
        }
        /// <summary>
        /// Gets the industry view.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IIndustryListView GetIndustryView(IIndustryListView industryView, string message)
        {
            return this.generalFactory.CreateIndustryView(industryView, message);
        }

        /// <summary>
        /// Updates the industry information.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">industryView</exception>
        public string UpdateIndustryInfo(IIndustryListView industryView)
        {
            if (industryView == null)
            {
                throw new ArgumentNullException(nameof(industryView));
            }

            var processingMessages = string.Empty;

            var dataValue = this.generalRepository.GetIndustryDescriptionByValue(industryView.IndustryName);
            if ( dataValue != null)
            {
                processingMessages = Messages.IndustryExist;
                return processingMessages;
            }
            var editIndustry = this.generalRepository.EditIndustry(industryView);

            return editIndustry;
        }
        /// <summary>
        /// Gets the industry view.
        /// </summary>
        /// <returns></returns>
        public IIndustryView GetIndustryView()
        {
            return this.generalFactory.CreateIndustryView();
        }
        /// <summary>
        /// Processes the industry information.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <returns></returns>
        public string ProcessIndustryInfo(IIndustryListView industryView)
        {

            var processingMessages = string.Empty;

            var dataValue = this.generalRepository.GetIndustryDescriptionByValue(industryView.IndustryName);
            if (dataValue != null)
            {
                processingMessages = Messages.IndustryExist;
                return processingMessages;
            }

            processingMessages = this.generalRepository.SaveIndustryInfo(industryView);

            return processingMessages;
        }
        /// <summary>
        /// Processes the delete industry information.
        /// </summary>
        /// <param name="IndustryId">The industry identifier.</param>
        /// <returns></returns>
        public string ProcessDeleteIndustryInfo(int IndustryId)
        {
            var IndustryEditing = this.generalRepository.DeleteIndustryInfo(IndustryId);
            return IndustryEditing;
        }
        #endregion

     


        #region        Agent Of Deduction
        /// <summary>
        /// Gets the agent of deduction view model.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IAgentOfDeductionListView GetAgentOfDeductionViewModel(int selectedId, string selectedDescription, string message)
        {
            var agentOfDeductionCollection = this.generalRepository.GetAgentOFDeduction().ToList();

            return this.generalFactory.CreateAgentOfDeductionListView(selectedId, selectedDescription, agentOfDeductionCollection, message);



        }

        /// <summary>
        /// Deactivates the agent of deduction.
        /// </summary>
        /// <param name="agentOfDeductionId">The agent of deduction identifier.</param>
        /// <returns></returns>
        public string DeactivateAgentOfDeduction(int agentOfDeductionId)
        {
            return this.generalRepository.DeactivateAgentOfDeduction(agentOfDeductionId);
        }
        /// <summary>
        /// Deactivates the agent of deduction.
        /// </summary>
        /// <param name="agentOfDeductionId">The agent of deduction identifier.</param>
        /// <returns></returns>
        public string ActivateAgentOfDeduction(int agentOfDeductionId)
        {
            return this.generalRepository.ActivateAgentOfDeduction(agentOfDeductionId);
        }

        #endregion


        #region   InlandRevenue  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string ReactivateInlandRevenue(int Id)
        {
            return this.generalRepository.ReactivateInlandRevenue(Id);
        }
        /// <summary>
        /// Gets the inland revenue ListView model.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedInlandRevenueName">Name of the selected inland revenue.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IInlandRevenueListView GetInlandRevenueListViewModel(int selectedId, string selectedInlandRevenueName, string message)
        {
            var inlandRevenueCollection = this.generalRepository.GetInlandRevenue().ToList();
            return this.generalFactory.CreateInlandRevenueListView(selectedId,  selectedInlandRevenueName, inlandRevenueCollection, message);
        }

        /// <summary>
        /// Gets the selected inland revenue.
        /// </summary>
        /// <param name="inlandRevenueId">The inland revenue identifier.</param>
        /// <param name="infoMessage">The information message.</param>
        /// <returns></returns>
        public IInlandRevenueListView GetSelectedInlandRevenue(int inlandRevenueId, string infoMessage)
        {
            var inlandRevenue = this.generalRepository.GetInlandRevenueById(inlandRevenueId);

            return this.generalFactory.CreateEditInlandRevenueView(inlandRevenue);
        }

        /// <summary>
        /// Gets the selected inland revenue by information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public IInlandRevenueView GetSelectedInlandRevenueByInfo(int Id)
        {
            var inlandRevenueById = this.generalRepository.GetInlandRevenueById(Id);
            return this.generalFactory.CreateInlandRevenueView(inlandRevenueById);
        }

        /// <summary>
        /// Gets the inland revenue view.
        /// </summary>
        /// <param name="inlandRevenueView">The inland revenue view.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IInlandRevenueListView GetInlandRevenueView(IInlandRevenueListView inlandRevenueView, string message)
        {
            return this.generalFactory.CreateInlandRevenueView(inlandRevenueView, message);
        }

        /// <summary>
        /// Updates the inland revenue information.
        /// </summary>
        /// <param name="inlandRevenueView">The inland revenue view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">inlandRevenueView</exception>
        public string UpdateInlandRevenueInfo(IInlandRevenueListView inlandRevenueView)
        {
            if (inlandRevenueView == null)
            {
                throw new ArgumentNullException(nameof(inlandRevenueView));
            }


            var processingMessages = string.Empty;

            var dataValue = this.generalRepository.GetInlandRevenueNameByValue(inlandRevenueView.InlandRevenueName);
            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.InlandRevenueExist;
                return processingMessages;
            }


            var editInlandRevenue = this.generalRepository.EditInlandRevenue(inlandRevenueView);

            return editInlandRevenue;
        }

        /// <summary>
        /// Gets the inland revenue view.
        /// </summary>
        /// <returns></returns>
        public IInlandRevenueView GetInlandRevenueView()
        {
            return this.generalFactory.CreateInlandRevenueView();
        }

        /// <summary>
        /// Processes the inland revenue information.
        /// </summary>
        /// <param name="inlandRevenueView">The inland revenue view.</param>
        /// <returns></returns>
        public string ProcessInlandRevenueInfo(IInlandRevenueListView inlandRevenueView)
        {

            var processingMessages = string.Empty;

            var dataValue = this.generalRepository.GetInlandRevenueNameByValue(inlandRevenueView.InlandRevenueName);
            var isRecordExist = (dataValue == null) ? false : true;
            if (isRecordExist)
            {
                processingMessages = Messages.InlandRevenueExist;
                return processingMessages;
            }

            processingMessages = this.generalRepository.SaveInlandRevenueInfo(inlandRevenueView);

            return processingMessages;
        }


        public string ProcessDeleteInlandRevenueInfo(int InlandRevenueId)
        {
            var viewModel = this.generalRepository.DeleteInlandRevenueInfo(InlandRevenueId);
            return viewModel;
        }

        #endregion  InlandRevenue


        #region TaxAuthority        
        
        /// <summary>
        /// Gets the tax authority ListView model.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ITaxAuthorityListView GetTaxAuthorityListViewModel(int selectedId, string selectedDescription, string message)
        {
            var taxAuthorityCollection = this.generalRepository.GetTaxAuthority().ToList();

            return this.generalFactory.CreateTaxAuthorityListView(selectedId, selectedDescription, taxAuthorityCollection, message);



        }
        /// <summary>
        /// Deactivates the tax autority.
        /// </summary>
        /// <param name="taxAuthorityId">The tax authority identifier.</param>
        /// <returns></returns>
        public string ActivateTaxAutority(int taxAuthorityId)
        {
            return this.generalRepository.ActivateTaxAuthority(taxAuthorityId);
        }
        /// <summary>
        /// Des the activate tax authority.
        /// </summary>
        /// <param name="taxAuthorityId">The tax authority identifier.</param>
        /// <returns></returns>
        public string DeActivateTaxAuthority(int taxAuthorityId)
        {
            return this.generalRepository.DeActivateTaxAuthority(taxAuthorityId);
        }

        #endregion

        #region Upload Excel

        public string ProcessUploadExcelMainInfo(HttpPostedFileBase excelSheet,IDigitalFileView digitalFileView)
        {
            // save files uploaded by calling digital file services, the id returned will be zero if no files are uploaded - no need to check anything here
            var processingExcelMessage =
                digitalFileServices.SaveFile(FileType.Image, excelSheet, digitalFileView);

            // check that both files saved correctly
            if (!string.IsNullOrEmpty(processingExcelMessage))
            {
                var message = string.Format("{0}", processingExcelMessage);
                return message;
            }
            return processingExcelMessage;

        }

        /// <summary>
        /// Gets the upload excel view.
        /// </summary>
        /// <returns></returns>
        public IDigitalFileView GetUploadExcelView()
        {
            var fileType = this.generalRepository.GetFileType(); 
            return this.generalFactory.CreateUploadExcelView(fileType);
        }

        /// <summary>
        /// Gets the upload excel view.
        /// </summary>
        /// <param name="digitalFileView">The digital file view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IDigitalFileView GetUploadExcelView(IDigitalFileView digitalFileView, string processingMessage)  
        {
            var fileType = this.generalRepository.GetFileType();
            return this.generalFactory.CreateUploadExcelView(digitalFileView,processingMessage, fileType);
        }


        public IDigitalFile GetExcelFileForDownload(int id)
        {
            var digitalFile =
                digitalFileRepository.GetDigitalFileDetail(id);
            return digitalFile;
        }


        #endregion

    }
}