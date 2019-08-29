using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Interfaces;

namespace Pitalytics.Repositories.Models
{
   public  class InlandRevenueModel : IInlandRevenue
    {

        /// <summary>
        /// Gets or sets the revenue identifier.
        /// </summary>
        /// <value>
        /// The revenue identifier.
        /// </value>
        public int InlandRevenueId { get; set; }

        /// <summary>
        /// Gets or sets the name of the revenue.
        /// </summary>
        /// <value>
        /// The name of the revenue.
        /// </value>
        public string InlandRevenueName { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public Nullable<System.DateTime> DateCreated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

    }
}
