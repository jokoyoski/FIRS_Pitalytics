using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
    public interface ITaxAuthority
    {
        /// <summary>
        /// Gets or sets the tax authority identifier.
        /// </summary>
        /// <value>
        /// The tax authority identifier.
        /// </value>
        int TaxAuthorityId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the revenue identifier.
        /// </summary>
        /// <value>
        /// The revenue identifier.
        /// </value>
        int InlandRevenueId { get; set; }

        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
        int JurisdictionId { get; set; }

        /// <summary>
        /// Gets or sets the user registration identifier.
        /// </summary>
        /// <value>
        /// The user registration identifier.
        /// </value>
        int UserRegistrationId { get; set; }



        /// <summary>
        /// Gets or sets the name of the jurisdiction.
        /// </summary>
        /// <value>
        /// The name of the jurisdiction.
        /// </value>
        string JurisdictionName { get; set; }

        /// <summary>
        /// Gets or sets the name of the inland revenue.
        /// </summary>
        /// <value>
        /// The name of the inland revenue.
        /// </value>
         string InlandRevenueName { get; set; }

    }
}
