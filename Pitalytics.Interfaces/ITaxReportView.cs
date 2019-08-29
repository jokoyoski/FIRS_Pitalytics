using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pitalytics.Interfaces
{
    public interface ITaxReportView
    {
        /// <summary>
        /// Gets or sets the tax report identifier.
        /// </summary>
        /// <value>
        /// The tax report identifier.
        /// </value>
        int TaxReportId { get; set; }
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        string Year { get; set; }
        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        int IncomeTypeId { get; set; }
        /// <summary>
        /// Gets or sets the BVN.
        /// </summary>
        /// <value>
        /// The BVN.
        /// </value>
        string BVN { get; set; }
        /// <summary>
        /// Gets or sets the income amount.
        /// </summary>
        /// <value>
        /// The income amount.
        /// </value>
        decimal IncomeAmount { get; set; }
        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        /// <value>
        /// The tax amount.
        /// </value>
        decimal TaxAmount { get; set; }
        /// <summary>
        /// Gets or sets the income types.
        /// </summary>
        /// <value>
        /// The income types.
        /// </value>
        IList<SelectListItem> IncomeTypes { get; set; }

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
        string BeneficiaryTIN { get; set; }

        /// <summary>
        /// Gets or sets the name of the income type.
        /// </summary>
        /// <value>
        /// The name of the income type.
        /// </value>
        string IncomeTypeName { get; set; }

       
        /// <summary>
        /// Gets or sets the file type identifier.
        /// </summary>
        /// <value>
        /// The file type identifier.
        /// </value>
        int? FileTypeId { get; set; }
        /// <summary>
        /// Gets or sets the tax report collection.
        /// </summary>
        /// <value>
        /// The tax report collection.
        /// </value>
        IList<ITaxReport> TaxReportCollection { get; set; }

    }
}
