using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{    
   public interface IInlandRevenueView
    {
        /// <summary>
        /// Gets or sets the inland revenue identifier.
        /// </summary>
        /// <value>
        /// The inland revenue identifier.
        /// </value>
        int InlandRevenueId { get; set; }
        /// <summary>
        /// Gets or sets the name of the inland revenue.
        /// </summary>
        /// <value>
        /// The name of the inland revenue.
        /// </value>
        string InlandRevenueName { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
