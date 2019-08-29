using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Domain.Models
{
   public class InlandRevenueView : IInlandRevenueView
    {
        /// <summary>
        /// Gets or sets the inland revenue identifier.
        /// </summary>
        /// <value>
        /// The inland revenue identifier.
        /// </value>
        public int InlandRevenueId { get; set; }
        /// <summary>
        /// Gets or sets the name of the inland revenue.
        /// </summary>
        /// <value>
        /// The name of the inland revenue.
        /// </value>
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string InlandRevenueName { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
