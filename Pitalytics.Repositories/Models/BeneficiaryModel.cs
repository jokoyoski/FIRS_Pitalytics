using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Interfaces;

namespace Pitalytics.Repositories.Models
{
    public class BeneficiaryModel : IBeneficiary
    {
        /// <summary>
        /// Gets or sets the beneficiary identifier.
        /// </summary>
        /// <value>
        /// The beneficiary identifier.
        /// </value>
        public int BeneficiaryId { get; set; }

        /// <summary>
        /// Gets or sets the cac reg no.
        /// </summary>
        /// <value>
        /// The cac reg no.
        /// </value>
        public int CACRegNo { get; set; }

        /// <summary>
        /// Gets or sets the BVN.
        /// </summary>
        /// <value>
        /// The BVN.
        /// </value>
        public string BVN { get; set; }

        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
        public int JurisdictionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the beneficiary.
        /// </summary>
        /// <value>
        /// The name of the beneficiary.
        /// </value>
        public string BeneficiaryName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

    }
}
