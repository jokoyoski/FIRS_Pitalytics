using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces 
{
    /// <summary>
    /// 
    /// </summary>
    public interface IJurisdiction
    {
        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
        int JurisdictionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the jurisdiction.
        /// </summary>
        /// <value>
        /// The name of the jurisdiction.
        /// </value>
        string JurisdictionName { get; set; }

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
        Nullable<System.DateTime> DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

    }
}
