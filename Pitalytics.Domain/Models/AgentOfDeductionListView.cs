using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Domain.Models
{
    public class AgentOfDeductionListView : IAgentOfDeductionListView
    {
        public IList<IAgentOfDeduction> AgentOfDeductions { get; set; }

        public string ProcessingMessage { get; set; }
    }
}