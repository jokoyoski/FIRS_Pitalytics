using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
    public interface IRoleStatus
    {
        /// <summary>
        /// Gets or sets the admin role.
        /// </summary>
        /// <value>
        /// The admin role.
        /// </value>
        string AdminRole { get; set; }
        /// <summary>
        /// Gets or sets the user role.
        /// </summary>
        /// <value>
        /// The user role.
        /// </value>
        string UserRole { get; set; }
        /// <summary>
       
        /// <summary>
        /// Gets or sets the user role identifier.
        /// </summary>
        /// <value>
        /// The user role identifier.
        /// </value>
        int UserRoleId { get; set; }
        /// <summary>
        /// Gets or sets the admin role identifier.
        /// </summary>
        /// <value>
        /// The admin role identifier.
        /// </value>
         int AdminRoleId { get; set; }

    }
}
