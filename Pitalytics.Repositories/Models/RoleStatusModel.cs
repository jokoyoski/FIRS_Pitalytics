using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Interfaces;

namespace Pitalytics.Repositories.Models
{
    public class RoleStatusModel : IRoleStatus
    {
        /// <summary>
        /// Gets or sets the admin role.
        /// </summary>
        /// <value>
        /// The admin role.
        /// </value>
        public string AdminRole { get; set; }
        /// <summary>
        /// Gets or sets the user role.
        /// </summary>
        /// <value>
        /// The user role.
        /// </value>
        public string UserRole { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public int UserRoleId { get; set; }
        /// <summary>
        /// Gets or sets the admin role identifier.
        /// </summary>
        /// <value>
        /// The admin role identifier.
        /// </value>
        public int AdminRoleId { get; set; }

    }
}
