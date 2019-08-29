using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
   public interface IInlandRevenueListView
    {
        /// <summary>
        /// Gets or sets the selected inland revenue identifier.
        /// </summary>
        /// <value>
        /// The selected inland revenue identifier.
        /// </value>
        int SelectedInlandRevenueId { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected inland revenue.
        /// </summary>
        /// <value>
        /// The name of the selected inland revenue.
        /// </value>
        string SelectedInlandRevenueName { get; set; }

        /// <summary>
        /// Gets or sets the inland revenue collection.
        /// </summary>
        /// <value>
        /// The inland revenue collection.
        /// </value>
        IList<IInlandRevenue> InlandRevenueCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the inland revenue.
        /// </summary>
        /// <value>
        /// The inland revenue.
        /// </value>
        string InlandRevenueName { get; set; }

        /// <summary>
        /// Gets or sets the inland revenue identifier.
        /// </summary>
        /// <value>
        /// The inland revenue identifier.
        /// </value>
        int InlandRevenueId { get; set; }
    }
}
