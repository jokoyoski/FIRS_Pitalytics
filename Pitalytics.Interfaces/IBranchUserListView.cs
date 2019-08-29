using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pitalytics.Interfaces
{
    public interface IBranchUserListView
    {  /// <summary>
       /// Gets or sets the branch names.
       /// </summary>
       /// <value>
       /// The branch names.
       /// </value>
        IList<SelectListItem> BranchNames { get; set; }

        /// <summary>
        /// Gets or sets the user names.
        /// </summary>
        /// <value>
        /// The user names.
        /// </value>
        IList<SelectListItem> UserNames { get; set; }
        /// <summary>
        /// Gets or sets the user branches.
        /// </summary>
        /// <value>
        /// The user branches.
        /// </value>
        IList<IUserBranch> UserBranches { get; set; }

        /// <summary>
        /// Gets or sets the branch identifier.
        /// </summary>
        /// <value>
        /// The branch identifier.
        /// </value>
        int BranchId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }
        /// <summary>
        /// Gets or sets the name of the branch.
        /// </summary>
        /// <value>
        /// The name of the branch.
        /// </value>
        string BranchName { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string processingMessage { get; set; }
    }
}