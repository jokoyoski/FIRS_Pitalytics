using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Interfaces;

namespace Pitalytics.Repositories.Models
{
    public class TaxAuthorityModel : ITaxAuthority
    {

        /// <summary>
        /// Gets or sets the tax authority identifier.
        /// </summary>
        /// <value>
        /// The tax authority identifier.
        /// </value>
        public int TaxAuthorityId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the revenue identifier.
        /// </summary>
        /// <value>
        /// The revenue identifier.
        /// </value>
        public int InlandRevenueId { get; set; }

        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
        public int JurisdictionId { get; set; }

        /// <summary>
        /// Gets or sets the user registration identifier.
        /// </summary>
        /// <value>
        /// The user registration identifier.
        /// </value>
        public int UserRegistrationId { get; set; }

        /// <summary>
        /// Gets or sets the name of the jurisdiction.
        /// </summary>
        /// <value>
        /// The name of the jurisdiction.
        /// </value>
        public string JurisdictionName { get; set; }

        /// <summary>
        /// Gets or sets the name of the inland revenue.
        /// </summary>
        /// <value>
        /// The name of the inland revenue.
        /// </value>
        public string InlandRevenueName { get; set; }

    }
}
