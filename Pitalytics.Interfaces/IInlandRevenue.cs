using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
    public interface IInlandRevenue
    {

        /// <summary>
        /// Gets or sets the revenue identifier.
        /// </summary>
        /// <value>
        /// The revenue identifier.
        /// </value>
        int InlandRevenueId { get; set; }

        /// <summary>
        /// Gets or sets the name of the revenue.
        /// </summary>
        /// <value>
        /// The name of the revenue.
        /// </value>
        string InlandRevenueName { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        Nullable<System.DateTime> DateCreated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

    }
}
