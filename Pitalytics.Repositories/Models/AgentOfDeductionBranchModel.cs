﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Interfaces;

namespace Pitalytics.Repositories.Models
{
 public  class AgentOfDeductionBranchModel : IAgentOfDeductionBranch
    {
        /// <summary>
        /// Gets or sets the agent of deduction branch identifier.
        /// </summary>
        /// <value>
        /// The agent of deduction branch identifier.
        /// </value>
        public int AgentOfDeductionBranchId { get; set; }

        /// <summary>
        /// Gets or sets the agent of deduction identifier.
        /// </summary>
        /// <value>
        /// The agent of deduction identifier.
        /// </value>
        public int AgentOfDeductionId { get; set; }

        /// <summary>
        /// Gets or sets the branch identifier.
        /// </summary>
        /// <value>
        /// The branch identifier.
        /// </value>
        public int BranchId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public Nullable<System.DateTime> DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the name of the branch.
        /// </summary>
        /// <value>
        /// The name of the branch.
        /// </value>
        public string BranchName { get; set; }

        /// <summary>
        /// Gets or sets the name of the agent of deduction.
        /// </summary>
        /// <value>
        /// The name of the agent of deduction.
        /// </value>
        public string AgentOfDeductionName { get; set; }

    }
}
