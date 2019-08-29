using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
   public  interface IAgentOfDeductionBranchListView
    {
        /// <summary>
        /// Gets or sets the agent of deduction branches.
        /// </summary>
        /// <value>
        /// The agent of deduction branches.
        /// </value>
        IList<IAgentOfDeductionBranch> agentOfDeductionBranches { get; set; }
    }
}
