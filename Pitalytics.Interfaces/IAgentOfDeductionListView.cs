using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
  public  interface IAgentOfDeductionListView
    {
        /// <summary>
        /// Gets or sets the agent of deductions.
        /// </summary>
        /// <value>
        /// The agent of deductions.
        /// </value>
        IList<IAgentOfDeduction> AgentOfDeductions { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
