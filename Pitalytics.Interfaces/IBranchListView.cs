using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pitalytics.Interfaces
{
    public interface IBranchListView
    {
        /// <summary>
        /// Gets or sets the branch identifier.
        /// </summary>
        /// <value>
        /// The branch identifier.
        /// </value>
        int BranchId { get; set; }

        /// <summary>
        /// Gets or sets the name of the branch.
        /// </summary>
        /// <value>
        /// The name of the branch.
        /// </value>
        string BranchName { get; set; }
      

        /// <summary>
        /// Gets or sets the jurisdiction identifier.
        /// </summary>
        /// <value>
        /// The jurisdiction identifier.
        /// </value>
        int JurisdictionId { get; set; }
        /// <summary>
        /// Gets or sets the name of the jurisdiction.
        /// </summary>
        /// <value>
        /// The name of the jurisdiction.
        /// </value>
        string JurisdictionName { get; set; }
        /// <summary>
        /// Gets or sets the agent of deduction identifier.
        /// </summary>
        /// <value>
        /// The agent of deduction identifier.
        /// </value>
        int AgentOfDeductionId { get; set; }
        /// <summary>
        /// Gets or sets the name of the agent of deduction.
        /// </summary>
        /// <value>
        /// The name of the agent of deduction.
        /// </value>
        string AgentOfDeductionName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        Nullable<System.DateTime> DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        string UserName { get; set; }
        /// <summary>
        /// Gets or sets the branch collection.
        /// </summary>
        /// <value>
        /// The branch collection.
        /// </value>
        IList<IBranch> BranchCollection { get; set; }

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
        /// Gets or sets the jurisdiction names.
        /// </summary>
        /// <value>
        /// The jurisdiction names.
        /// </value>
        IList<SelectListItem> JurisdictionNames { get; set; }
        /// <summary>
        /// Gets or sets the income type names.
        /// </summary>
        /// <value>
        /// The income type names.
        /// </value>
        IList<SelectListItem> IncomeTypeNames { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the file type identifier.
        /// </summary>
        /// <value>
        /// The file type identifier.
        /// </value>
        int? FileTypeId { get; set; }

    }
}
