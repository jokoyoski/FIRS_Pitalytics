using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
    public interface IAppActivityLog
    {
        /// <summary>
        /// Gets or sets the application activity log identifier.
        /// </summary>
        /// <value>
        /// The application activity log identifier.
        /// </value>
        int AppActivityLogId { get; set; }

        /// <summary>
        /// Gets or sets the log date.
        /// </summary>
        /// <value>
        /// The log date.
        /// </value>
        System.DateTime LogDate { get; set; }

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        /// <value>
        /// The user email.
        /// </value>
        string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the activity.
        /// </summary>
        /// <value>
        /// The activity.
        /// </value>
        string Activity { get; set; }

        /// <summary>
        /// Gets or sets the order identifer.
        /// </summary>
        /// <value>
        /// The order identifer.
        /// </value>
        string OrderIdentifer { get; set; }

    }
}
