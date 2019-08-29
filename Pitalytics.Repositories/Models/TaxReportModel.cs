using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Interfaces;

namespace Pitalytics.Repositories.Models
{
    public class TaxReportModel : ITaxReport
    {
        /// <summary>
        /// Gets or sets the tax report identifier.
        /// </summary>
        /// <value>
        /// The tax report identifier.
        /// </value>
      public  int TaxReportId { get; set; }
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
      public  string Year { get; set; }
        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
      public  int IncomeTypeId { get; set; }
        /// <summary>
        /// Gets or sets the BVN.
        /// </summary>
        /// <value>
        /// The BVN.
        /// </value>
      public  string BVN { get; set; }
        /// <summary>
        /// Gets or sets the income amount.
        /// </summary>
        /// <value>
        /// The income amount.
        /// </value>
      public  decimal IncomeAmount { get; set; }
        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        /// <value>
        /// The tax amount.
        /// </value>
      public  decimal TaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the beneficiary tin.
        /// </summary>
        /// <value>
        /// The beneficiary tin.
        /// </value>
        public string BeneficiaryTIN { get; set; }
        /// <summary>
        /// Gets or sets the name of the income type.
        /// </summary>
        /// <value>
        /// The name of the income type.
        /// </value>
        public string IncomeTypeName { get; set; }

    }
}
