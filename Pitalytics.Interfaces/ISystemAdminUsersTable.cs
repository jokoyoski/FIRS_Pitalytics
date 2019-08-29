using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
   public interface ISystemAdminUsersTable
    {  /// <summary>
       /// Gets or sets the system admin usersid.
       /// </summary>
       /// <value>
       /// The system admin usersid.
       /// </value>
        int SystemAdminUsersid { get; set; }
        /// <summary>
        /// Gets or sets the system admin.
        /// </summary>
        /// <value>
        /// The system admin.
        /// </value>
         int SystemAdmin { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <vlue>
        /// The user identifier.
        /// </value>
         int UserId { get; set; }
    }
}
