using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Domain.Models
{
   public class AgentOfDeductionBranchListView :IAgentOfDeductionBranchListView
    { /// <summary>
      /// Gets or sets the agent of deduction branches.
      /// </summary>
      /// <value>
      /// The agent of deduction branches.
      /// </value>
      public  IList<IAgentOfDeductionBranch> agentOfDeductionBranches { get; set; }
    }
}
