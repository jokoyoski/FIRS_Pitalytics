using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Interfaces;

namespace Pitalytics.Repositories.Models
{
    public class IncomeReportModel : IIncomeReport
    {

        /// <summary>
        /// Gets or sets the income report identifier.
        /// </summary>
        /// <value>
        /// The income report identifier.
        /// </value>
        public int IncomeReportId { get; set; }

        /// <summary>
        /// Gets or sets the dividends.
        /// </summary>
        /// <value>
        /// The dividends.
        /// </value>
        public Nullable<decimal> Dividends { get; set; }

        /// <summary>
        /// Gets or sets the professional services.
        /// </summary>
        /// <value>
        /// The professional services.
        /// </value>
        public Nullable<decimal> ProfessionalServices { get; set; }

        /// <summary>
        /// Gets or sets the director fees.
        /// </summary>
        /// <value>
        /// The director fees.
        /// </value>
        public Nullable<decimal> DirectorFees { get; set; }

        /// <summary>
        /// Gets or sets the rent hire.
        /// </summary>
        /// <value>
        /// The rent hire.
        /// </value>
        public Nullable<decimal> RentHire { get; set; }

        /// <summary>
        /// Gets or sets the interest.
        /// </summary>
        /// <value>
        /// The interest.
        /// </value>
        public Nullable<decimal> Interest { get; set; }

        /// <summary>
        /// Gets or sets the construction.
        /// </summary>
        /// <value>
        /// The construction.
        /// </value>
        public Nullable<decimal> Construction { get; set; }

        /// <summary>
        /// Gets or sets the contract of supplies.
        /// </summary>
        /// <value>
        /// The contract of supplies.
        /// </value>
        public Nullable<decimal> ContractOfSupplies { get; set; }

        /// <summary>
        /// Gets or sets the contract of services.
        /// </summary>
        /// <value>
        /// The contract of services.
        /// </value>
        public Nullable<decimal> ContractOfServices { get; set; }

        /// <summary>
        /// Gets or sets the technical consultancy.
        /// </summary>
        /// <value>
        /// The technical consultancy.
        /// </value>
        public Nullable<decimal> TechnicalConsultancy { get; set; }

        /// <summary>
        /// Gets or sets the management comm.
        /// </summary>
        /// <value>
        /// The management comm.
        /// </value>
        public Nullable<decimal> ManagementComm { get; set; }

        /// <summary>
        /// Gets or sets the royalty.
        /// </summary>
        /// <value>
        /// The royalty.
        /// </value>
        public Nullable<decimal> Royalty { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public string DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the beneficiary tin.
        /// </summary>
        /// <value>
        /// The beneficiary tin.
        /// </value>
        public string BeneficiaryTin { get; set; }

        /// <summary>
        /// Gets or sets the BVN.
        /// </summary>
        /// <value>
        /// The BVN.
        /// </value>
        public string BVN { get; set; }
    }
}
