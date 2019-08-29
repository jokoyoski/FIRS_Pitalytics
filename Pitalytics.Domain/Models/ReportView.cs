using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Interfaces;

namespace Pitalytics.Domain.Models
{
    public class ReportView : IReportView
    {
        /// <summary>
        /// Gets or sets the tax report.
        /// </summary>
        /// <value>
        /// The tax report.
        /// </value>
        public IList<ITaxReport> TaxReport { get; set; }
        /// <summary>
        /// Gets or sets the income report.
        /// </summary>
        /// <value>
        /// The income report.
        /// </value>
        public IList<IIncomeReport> IncomeReport { get; set; }

        /// <summary>
        /// Gets or sets the report collection.
        /// </summary>
        /// <value>
        /// The report collection.
        /// </value>
        public IList<IReportView> ReportCollection { get; set; }
    }
}
