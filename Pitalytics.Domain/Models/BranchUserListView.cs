using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pitalytics.Domain.Models
{
    public class BranchUserListView : IBranchUserListView
    {

        /// <summary>
        /// Gets or sets the branch names.
        /// </summary>
        /// <value>
        /// The branch names.
        /// </value>
        public IList<SelectListItem> BranchNames { get; set; }

        /// <summary>
        /// Gets or sets the user names.
        /// </summary>
        /// <value>
        /// The user names.
        /// </value>
        public IList<SelectListItem> UserNames { get; set; }


        /// Gets or sets the branch identifier.
        /// </summary>
        /// <value>
        /// The branch identifier.
        /// </value>
        public int BranchId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the name of the branch.
        /// </summary>
        /// <value>
        /// The name of the branch.
        /// </value>
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string BranchName { get; set; }

        /// <summary>
        /// Gets or sets the user branches.
        /// </summary>
        /// <value>
        /// The user branches.
        /// </value>
        public IList<IUserBranch> UserBranches { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string processingMessage { get; set; }


    }
}



