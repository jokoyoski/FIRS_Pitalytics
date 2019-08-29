using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
   public interface IReportView 
    {
        /// <summary>
        /// Gets or sets the tax report.
        /// </summary>
        /// <value>
        /// The tax report.
        /// </value>
        IList<ITaxReport> TaxReport { get; set; }
        /// <summary>
        /// Gets or sets the income report.
        /// </summary>
        /// <value>
        /// The income report.
        /// </value>
        IList<IIncomeReport> IncomeReport { get; set; }

        /// <summary>
        /// Gets or sets the report collection.
        /// </summary>
        /// <value>
        /// The report collection.
        /// </value>
        IList<IReportView> ReportCollection { get; set; }
    }
}
