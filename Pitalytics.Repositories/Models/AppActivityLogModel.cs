using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Interfaces;

namespace Pitalytics.Repositories.Models
{
    public class AppActivityLogModel : IAppActivityLog
    {
        /// <summary>
        /// Gets or sets the application activity log identifier.
        /// </summary>
        /// <value>
        /// The application activity log identifier.
        /// </value>
        public int AppActivityLogId { get; set; }

        /// <summary>
        /// Gets or sets the log date.
        /// </summary>
        /// <value>
        /// The log date.
        /// </value>
        public System.DateTime LogDate { get; set; }

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        /// <value>
        /// The user email.
        /// </value>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the activity.
        /// </summary>
        /// <value>
        /// The activity.
        /// </value>
        public string Activity { get; set; }

        /// <summary>
        /// Gets or sets the order identifer.
        /// </summary>
        /// <value>
        /// The order identifer.
        /// </value>
        public string OrderIdentifer { get; set; }

    }
}
