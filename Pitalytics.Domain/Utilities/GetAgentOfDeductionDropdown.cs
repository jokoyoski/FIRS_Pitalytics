using Pitalytics.Domain.Resources;
using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pitalytics.Domain.Utilities
{
   public  class GetAgentOfDeductionDropdown
    {// </summary>
        // <summary>
        /// Colors the list items.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="selectedColorId">The selected color identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> AgentOfDeductionListItems(IList<IAgentOfDeduction> agentOfDeductions,
           int selectedagentId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectAgentOfDeduction,
                    Value = "-1",
                    Selected = false
                }
            };

            if (agentOfDeductions.Any())
            {
                list.AddRange(agentOfDeductions.Select(t => new SelectListItem
                {
                    Text = t.CompanyName,
                    Value = t.AgentOfDeductionId.ToString(),
                    Selected = selectedagentId.Equals(t.AgentOfDeductionId)
                }));
            }

            return list;
        }

    }

}