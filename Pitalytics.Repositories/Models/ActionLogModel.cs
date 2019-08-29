using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Interfaces;

namespace Pitalytics.Repositories.Models
{
  public  class ActionLogModel : IActionLog
    {

        /// <summary>
        /// Gets or sets the action log identifier.
        /// </summary>
        /// <value>
        /// The action log identifier.
        /// </value>
        public int ActionLogId { get; set; }

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        /// <value>
        /// The user email.
        /// </value>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the log date.
        /// </summary>
        /// <value>
        /// The log date.
        /// </value>
        public System.DateTime LogDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Pitalytic.Interfaces.IActionLog" /> is granted.
        /// </summary>
        /// <value>
        /// <c>true</c> if granted; otherwise, <c>false</c>.
        /// </value>
        public bool Granted { get; set; }

        /// <summary>
        /// Gets or sets the date stamp.
        /// </summary>
        /// <value>
        /// The date stamp.
        /// </value>
        public System.DateTime DateStamp { get; set; }
    }
}
