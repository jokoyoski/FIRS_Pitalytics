using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
    public interface IActionLog
    {
        /// <summary>
        /// Gets or sets the action log identifier.
        /// </summary>
        /// <value>
        /// The action log identifier.
        /// </value>
        int ActionLogId { get; set; }

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        /// <value>
        /// The user email.
        /// </value>
        string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        string Action { get; set; }

        /// <summary>
        /// Gets or sets the log date.
        /// </summary>
        /// <value>
        /// The log date.
        /// </value>
        System.DateTime LogDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IActionLog"/> is granted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if granted; otherwise, <c>false</c>.
        /// </value>
        bool Granted { get; set; }

        /// <summary>
        /// Gets or sets the date stamp.
        /// </summary>
        /// <value>
        /// The date stamp.
        /// </value>
        System.DateTime DateStamp { get; set; }

    }
}
