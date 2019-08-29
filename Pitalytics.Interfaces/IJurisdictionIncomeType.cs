using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
    public interface IJurisdictionIncomeType
    {
        /// <summary>
        /// Gets or sets the jurisdiction income type identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction income type identifier.
        /// </value>
        int JurisdictionIncomeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
        int JurisdictionId { get; set; }

        /// <summary>
        /// Gets or sets the income type identifier.
        /// </summary>
        /// <value>
        /// The income type identifier.
        /// </value>
        int IncomeTypeId { get; set; }

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
        Nullable<System.DateTime> DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the name of the jurisdiction.
        /// </summary>
        /// <value>
        /// The name of the jurisdiction.
        /// </value>
        string JurisdictionName { get; set; }
        /// <summary>
        /// Gets or sets the name of the income type.
        /// </summary>
        /// <value>
        /// The name of the income type.
        /// </value>
        string IncomeTypeName { get; set; }

    }
}
