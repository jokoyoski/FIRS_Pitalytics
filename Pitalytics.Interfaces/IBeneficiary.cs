using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
    public interface IBeneficiary
    {
        /// <summary>
        /// Gets or sets the beneficiary identifier.
        /// </summary>
        /// <value>
        /// The beneficiary identifier.
        /// </value>
        int BeneficiaryId { get; set; }

        /// <summary>
        /// Gets or sets the cac reg no.
        /// </summary>
        /// <value>
        /// The cac reg no.
        /// </value>
        int CACRegNo { get; set; }

        /// <summary>
        /// Gets or sets the BVN.
        /// </summary>
        /// <value>
        /// The BVN.
        /// </value>
        string BVN { get; set; }

        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
        int JurisdictionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the beneficiary.
        /// </summary>
        /// <value>
        /// The name of the beneficiary.
        /// </value>
        string BeneficiaryName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

    }
}
