using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Domain.Models;
using Pitalytics.Domain.Utilities;


namespace Pitalytics.Domain.Factories
{
    public class GeneralFactory : IGeneralFactory
    {

        #region IncomeType
        /// <summary>
        /// Creates the income type ListView.
        /// </summary>
        /// <param name="selectedIncomeTypeId">The selected income type identifier.</param>
        /// <param name="selectedIncomeTypeName">Name of the selected income type.</param>
        /// <param name="selectedDescription">The selected description.</param>
        /// <param name="selectedWHT_Rate">The selected WHT rate.</param>
        /// <param name="selectedIsActive">if set to <c>true</c> [selected is active].</param>
        /// <param name="selectedDateCreated">The selected date created.</param>
        /// <param name="incomeTypeCollection">The income type collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">incomeTypeCollection</exception>
        public IIncomeTypeListView CreateIncomeTypeListView(int selectedId, string selectedDescription, IList<IIncomeType> incomeTypeCollection, string message)
        {
            if (incomeTypeCollection == null)
            {
                throw new ArgumentNullException(nameof(incomeTypeCollection));
            }
          
            var returnView = new IncomeTypeListView
            {
                SelectedIncomeTypeId = selectedId,
                SelectedDescription = selectedDescription,

                IncomeTypeCollection = incomeTypeCollection,
               
                ProcessingMessage = message ?? ""


            };
            return returnView;

        }


        /// <summary>
        /// Creates the income type view.
        /// </summary>
        /// <param name="incomeTypeView">The income type view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">incomeTypeView</exception>
        public IIncomeTypeListView CreateIncomeTypeView(IIncomeTypeListView incomeTypeView, string processingMessage)
        {
            if (incomeTypeView == null)
            {
                throw new ArgumentException("incomeTypeView");
            }


            incomeTypeView.ProcessingMessage = processingMessage;
            return incomeTypeView;
        }



        /// <summary>
        /// Creates the income type jurisdiction view.
        /// </summary>
        /// <param name="jurisdictions">The jurisdictions.</param>
        /// <param name="incomeTypes">The income types.</param>
        /// <param name="jurisdictionIncomeTypes">The jurisdiction income types.</param>
        /// <returns></returns>
        public IIncomeTypeListView CreateIncomeTypeJurisdictionView(IList<IJurisdiction> jurisdictions, IList<IIncomeType> incomeTypes)

        {
            var incomeTypeDDL = GetDropdownIncomeTypeList.GetIncomeType(incomeTypes, -1);
            var jurisdictionDDL = GetJurisdictionDropdown.GetJurisdicions(jurisdictions, -1);
            var View = new IncomeTypeListView
            {
                IncomeTypeList = incomeTypeDDL,
                JurisdictionList = jurisdictionDDL,
                
            };
            return View;
        }
        /// <summary>
        /// Creates the income type jurisdiction view.
        /// </summary>
        /// <param name="jurisdictionIncomeTypes">The jurisdiction income types.</param>
        /// <returns></returns>
        public IIncomeTypeListView CreateIncomeTypeJurisdictionView(IList<IJurisdictionIncomeType> jurisdictionIncomeTypes, string infoMessage, IList<IIncomeType> incomeTypes, IList<IJurisdiction> jurisdictions,int jurisdictionId)

        {
            var incomeTypeDDL = GetDropdownIncomeTypeList.GetIncomeType(incomeTypes, -1);
            var jurisdictionDDL = GetJurisdictionDropdown.GetJurisdicions(jurisdictions, -1);

            var View = new IncomeTypeListView
            {
                IncomeTypeList = incomeTypeDDL,
                JurisdictionList = jurisdictionDDL,
                jurisdictionIncomeTypes = jurisdictionIncomeTypes,
                ProcessingMessage = infoMessage,
                JurisdictionId=jurisdictionId,
            };
            return View;
        }


        /// <summary>
        /// Creates the edit income type jurisdiction view.
        /// </summary>
        /// <param name="incomeTypes">The income types.</param>
        /// <returns></returns>
        public IIncomeTypeListView CreateEditIncomeTypeView(IIncomeType incomeTypes)

        {

            var View = new IncomeTypeListView
            {
                IncomeTypeName = incomeTypes.IncomeTypeName,
                IncomeTypeId = incomeTypes.IncomeTypeId,
            };
            return View;
        }





        /// <summary>
        /// Creates the updated income type jurisdiction view.
        /// </summary>
        /// <param name="jurisdictions">The jurisdictions.</param>
        /// <param name="incomeTypes">The income types.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="incomeTypeListView">The income type ListView.</param>
        /// <returns></returns>
        public IIncomeTypeListView CreateUpdatedIncomeTypeJurisdictionView(IList<IJurisdiction> jurisdictions, IList<IIncomeType> incomeTypes, string processingMessage, IIncomeTypeListView incomeTypeListView)

        {
            var incomeTypeDDL = GetDropdownIncomeTypeList.GetIncomeType(incomeTypes, -1);
            var jurisdictionDDL = GetJurisdictionDropdown.GetJurisdicions(jurisdictions, -1);

            incomeTypeListView.JurisdictionList = jurisdictionDDL;
            incomeTypeListView.IncomeTypeList = incomeTypeDDL;
            incomeTypeListView.ProcessingMessage = processingMessage;
            return incomeTypeListView;


        }
        #endregion




        #region Jurisdiction

        public IJurisdictionListView CreateJurisdictionListView(int selectedId, string selectedDescription, IList<IJurisdiction> jurisdcitionCollection, string message)
        {
            if (jurisdcitionCollection == null)
            {
                throw new ArgumentNullException(nameof(jurisdcitionCollection));
            }

            var returnView = new JurisdictionListView
            {
                JurisdictionCollection = jurisdcitionCollection,
                ProcessingMessage = message,
                SelectedDescription = selectedDescription


            };
            return returnView;

        }
        /// <summary>
        /// Creates the jurisdiction view.
        /// </summary>
        /// <param name="jurisdictionView">The jurisdiction view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">jurisdictionView</exception>
        public IJurisdictionListView CreateJurisdictionView(IJurisdiction jurisdictionListView)
        {
            if (jurisdictionListView == null) throw new ArgumentNullException(nameof(jurisdictionListView));
            var view = new JurisdictionListView
            {
                ProcessingMessage = "",
               
                JurisdictionId = jurisdictionListView.JurisdictionId,
                JurisdictionName = jurisdictionListView.JurisdictionName

            };

            return view;
        }
        /// <summary>
        /// Creates the jurisdiction view.
        /// </summary>
        /// <param name="jurisdictionView">The jurisdiction view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">jurisdictionView</exception>
        public IJurisdictionListView CreateJurisdictionView(IJurisdictionListView jurisdictionView, string processingMessage)
        {
            if (jurisdictionView == null)
            {
                throw new ArgumentException("jurisdictionView");
            }


            jurisdictionView.ProcessingMessage = processingMessage;
            return jurisdictionView;
        }
        /// <summary>
        /// Creates the jurisdiction view.
        /// </summary>
        /// <returns></returns>
        public IJurisdictionView CreateJurisdictionView()
        {
            var view = new JurisdictionView
            {
                ProcessingMessage = string.Empty
            };
            return view;
        }
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
        /// <exception cref="ArgumentNullException">industryCollection</exception>
        public IIndustryListView CreateIndustryListView(int selectedId, string selectedDescription, IList<IIndustry> industryCollection, string message)
        {
            if (industryCollection == null)
            {
                throw new ArgumentNullException(nameof(industryCollection));
            }


            var returnView = new IndustryListView
            {
                IndustryCollection = industryCollection,
                SelectedDescription = selectedDescription,
                ProcessingMessage = message ?? ""


            };
            return returnView;

        }



        /// <summary>
        /// Creates the industry view.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">industryView</exception>
        public IIndustryListView CreateIndustryView(IIndustry industryView)
        {
            if (industryView == null) throw new ArgumentNullException(nameof(industryView));
            var view = new IndustryListView
            {
                ProcessingMessage = "",
                IndustryId = industryView.IndustryId,
                IndustryName = industryView.IndustryName,
               

            };

            return view;
        }


        /// <summary>
        /// Creates the industry view.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">industryView</exception>
        public IIndustryListView CreateIndustryView(IIndustryListView industryView, string processingMessage)
        {
            if (industryView == null)
            {
                throw new ArgumentException("industryView");
            }


            industryView.ProcessingMessage = processingMessage;
            return industryView;
        }
        /// <summary>
        /// Creates the industry view.
        /// </summary>
        /// <returns></returns>
        public IIndustryView CreateIndustryView()
        {
            var view = new IndustryView
            {
                ProcessingMessage = string.Empty
            };
            return view;
        }

        /// <summary>
        /// Gets the edit industry view.
        /// </summary>
        /// <param name="industryView">The industry view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">industryView</exception>
        public IIndustryView GetEditIndustryView(IIndustry industryView)
        {
            if (industryView == null) throw new ArgumentNullException(nameof(industryView));
            var view = new IndustryView
            {
                ProcessingMessage = "",
                Description = industryView.Description,
                IndustryId = industryView.IndustryId
            };
            return view;
        }

        #endregion


        #region TaxAuthortiy

        public ITaxAuthorityListView CreateTaxAuthorityListView(int selectedId, string selectedDescription, IList<ITaxAuthority> taxAuthorityCollection, string message)
        {
            if (taxAuthorityCollection == null)
            {
                throw new ArgumentNullException(nameof(taxAuthorityCollection));
            }

            var returnView = new TaxAuthorityListView
            {
                ProcessingMessage = message,
                SelectedDescription = selectedDescription,
                TaxAuthorityCollection = taxAuthorityCollection

            };
            return returnView;

        }
        #endregion

        #region AgentOfDeduction

        public IAgentOfDeductionListView CreateAgentOfDeductionListView(int selectedId, string selectedDescription, IList<IAgentOfDeduction> agentOfDeductions, string message)
        {
            if (agentOfDeductions == null)
            {
                throw new ArgumentNullException(nameof(agentOfDeductions));
            }


            var filteredList = agentOfDeductions.Where(x => x.AgentOfDeductionId.Equals(selectedId < 1 ? x.AgentOfDeductionId : selectedId)).ToList();

            //filter with desciprtion
            filteredList = filteredList.Where(x => x.CompanyName.Contains(string.IsNullOrEmpty(selectedDescription) ? x.CompanyName : selectedDescription)).ToList();

            var returnView = new AgentOfDeductionListView
            {
                ProcessingMessage = message,

                AgentOfDeductions = agentOfDeductions

            };
            return returnView;
        }
        #endregion



     #region Inland Revenue Setup        
        /// <summary>
        /// Creates the inland revenue ListView.
        /// </summary>
        /// <param name="selectedId">The selected identifier.</param>
        /// <param name="selectedInlandRevenueName">Name of the selected inland revenue.</param>
        /// <param name="inlandRevenueCollection">The inland revenue collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">inlandRevenueCollection</exception>
        public IInlandRevenueListView CreateInlandRevenueListView(int selectedId, string selectedInlandRevenueName, IList<IInlandRevenue> inlandRevenueCollection, string message)
        {
            if (inlandRevenueCollection == null)
            {
                throw new ArgumentNullException(nameof(inlandRevenueCollection));
            }

            // filter with colorId
            var filteredList = inlandRevenueCollection.Where(x => x.InlandRevenueId.Equals(selectedId < 1 ? x.InlandRevenueId : selectedId)).ToList();

            //filter with desciprtion
            filteredList = filteredList.Where(x => x.InlandRevenueName.Contains(string.IsNullOrEmpty(selectedInlandRevenueName) ? x.InlandRevenueName : selectedInlandRevenueName)).ToList();

            var returnView = new InlandRevenueListView
            {
                SelectedInlandRevenueId = selectedId,
                SelectedInlandRevenueName = selectedInlandRevenueName,



                InlandRevenueCollection = filteredList.ToList(),
                ProcessingMessage = message ?? ""


            };
            return returnView;

        }
        /// <summary>
        /// Creates the inland revenue view.
        /// </summary>
        /// <param name="inlandRevenueView">The inland revenue view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">inlandRevenueView</exception>
        public IInlandRevenueView CreateInlandRevenueView(IInlandRevenue inlandRevenueView)
        {
            if (inlandRevenueView == null) throw new ArgumentNullException(nameof(inlandRevenueView));
            var view = new InlandRevenueView
            {
                ProcessingMessage = "",
                InlandRevenueName = inlandRevenueView.InlandRevenueName,
                InlandRevenueId = inlandRevenueView.InlandRevenueId

            };

            return view;
        }

        /// <summary>
        /// Creates the inland revenue view.
        /// </summary>
        /// <param name="inlandRevenueView">The inland revenue view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">inlandRevenueView</exception>
        public IInlandRevenueListView CreateInlandRevenueView(IInlandRevenueListView inlandRevenueView, string processingMessage)
        {
            if (inlandRevenueView == null)
            {
                throw new ArgumentException("inlandRevenueView");
            }


            inlandRevenueView.ProcessingMessage = processingMessage;
            return inlandRevenueView;
        }

        /// <summary>
        /// Creates the inland revenue view.
        /// </summary>
        /// <returns></returns>
        public IInlandRevenueView CreateInlandRevenueView()
        {
            var view = new InlandRevenueView
            {
                ProcessingMessage = string.Empty
            };
            return view;
        }
        /// <summary>
        /// Creates the edit inland revenue view.
        /// </summary>
        /// <param name="inlandRevenues">The inland revenues.</param>
        /// <returns></returns>
        public IInlandRevenueListView CreateEditInlandRevenueView(IInlandRevenue inlandRevenues)

        {

            var View = new InlandRevenueListView
            {
                InlandRevenueName = inlandRevenues.InlandRevenueName,
                InlandRevenueId = inlandRevenues.InlandRevenueId,
            };
            return View;
        }


        #endregion

        #region Upload Excel              
        /// <summary>
        /// Creates the upload excel view.
        /// </summary>
        /// <param name="fileType">Type of the file.</param>
        /// <returns></returns>
        public IDigitalFileView CreateUploadExcelView(IList<IFileType> fileType) 
        {
            var fileTypeDDL = GetFileTypeDropdown.GetFileTypes(fileType, -1);
            var view = new DigitalFileView
            {
                ProcessingMessage = string.Empty,
                FileTypeList = fileTypeDDL,
            };
            return view;
        }

        /// <summary>
        /// Creates the digital file view.
        /// </summary>
        /// <param name="digitalFileView">The digital file view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">digitalFileView</exception>
        public IDigitalFileView CreateUploadExcelView(IDigitalFileView digitalFileView, string processingMessage, IList<IFileType> fileType)
        {

            if (digitalFileView == null)
            {
                throw new ArgumentException("digitalFileView");
            }

            var fileTypeDDL = GetFileTypeDropdown.GetFileTypes(fileType, -1);

            digitalFileView.ProcessingMessage = processingMessage;
            digitalFileView.FileTypeList = fileTypeDDL;
            return digitalFileView;
        }
        #endregion


    }
}