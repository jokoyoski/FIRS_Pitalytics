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
    public static class GetBranchDropdownList
    {/// </summary>
        // <summary>
        /// Colors the list items.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="selectedColorId">The selected color identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> BranchListItems(IList<IBranch> branches,
           int selectedBranchId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectBranch,
                    Value = "-1",
                    Selected = false
                }
            };

            if (branches.Any())
            {
                list.AddRange(branches.Select(t => new SelectListItem
                {
                    Text = t.BranchName,
                    Value = t.BranchId.ToString(),
                    Selected = selectedBranchId.Equals(t.BranchId)
                }));
            }

            return list;
        }

    }

}