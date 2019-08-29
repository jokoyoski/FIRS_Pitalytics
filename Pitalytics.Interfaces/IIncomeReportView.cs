using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
  
        public interface IIncomeReportView
        {
            /// <summary>
            /// Gets or sets the income report identifier.
            /// </summary>
            /// <value>
            /// The income report identifier.
            /// </value>
            int IncomeReportId { get; set; }

            /// <summary>
            /// Gets or sets the dividends.
            /// </summary>
            /// <value>
            /// The dividends.
            /// </value>
            Nullable<decimal> Dividends { get; set; }

            /// <summary>
            /// Gets or sets the professional services.
            /// </summary>
            /// <value>
            /// The professional services.
            /// </value>
            Nullable<decimal> ProfessionalServices { get; set; }

            /// <summary>
            /// Gets or sets the director fees.
            /// </summary>
            /// <value>
            /// The director fees.
            /// </value>
            Nullable<decimal> DirectorFees { get; set; }

            /// <summary>
            /// Gets or sets the rent hire.
            /// </summary>
            /// <value>
            /// The rent hire.
            /// </value>
            Nullable<decimal> RentHire { get; set; }

            /// <summary>
            /// Gets or sets the interest.
            /// </summary>
            /// <value>
            /// The interest.
            /// </value>
            Nullable<decimal> Interest { get; set; }

            /// <summary>
            /// Gets or sets the construction.
            /// </summary>
            /// <value>
            /// The construction.
            /// </value>
            Nullable<decimal> Construction { get; set; }

            /// <summary>
            /// Gets or sets the contract of supplies.
            /// </summary>
            /// <value>
            /// The contract of supplies.
            /// </value>
            Nullable<decimal> ContractOfSupplies { get; set; }

            /// <summary>
            /// Gets or sets the contract of services.
            /// </summary>
            /// <value>
            /// The contract of services.
            /// </value>
            Nullable<decimal> ContractOfServices { get; set; }

            /// <summary>
            /// Gets or sets the technical consultancy.
            /// </summary>
            /// <value>
            /// The technical consultancy.
            /// </value>
            Nullable<decimal> TechnicalConsultancy { get; set; }

            /// <summary>
            /// Gets or sets the management comm.
            /// </summary>
            /// <value>
            /// The management comm.
            /// </value>
            Nullable<decimal> ManagementComm { get; set; }

            /// <summary>
            /// Gets or sets the royalty.
            /// </summary>
            /// <value>
            /// The royalty.
            /// </value>
            Nullable<decimal> Royalty { get; set; }

            /// <summary>
            /// Gets or sets the date created.
            /// </summary>
            /// <value>
            /// The date created.
            /// </value>
            string DateCreated { get; set; }

            /// <summary>
            /// Gets or sets the processing message.
            /// </summary>
            /// <value>
            /// The processing message.
            /// </value>
            string ProcessingMessage { get; set; }

            /// <summary>
            /// Gets or sets the beneficiary tin.
            /// </summary>
            /// <value>
            /// The beneficiary tin.
            /// </value>
            string BeneficiaryTin { get; set; }

            /// <summary>
            /// Gets or sets the BVN.
            /// </summary>
            /// <value>
            /// The BVN.
            /// </value>
            string BVN { get; set; }


    }
    }


