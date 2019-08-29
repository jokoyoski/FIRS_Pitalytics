using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Repositories.Models
{
   public class SystemAdminUserModel : ISystemAdminUsersTable
    {
        /// <summary>
        /// Gets or sets the system admin usersid.
        /// </summary>
        /// <value>
        /// The system admin usersid.
        /// </value>
        public int SystemAdminUsersid { get; set; }
        /// <summary>
        /// Gets or sets the system admin.
        /// </summary>
        /// <value>
        /// The system admin.
        /// </value>
        public int SystemAdmin { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }
    }
}
