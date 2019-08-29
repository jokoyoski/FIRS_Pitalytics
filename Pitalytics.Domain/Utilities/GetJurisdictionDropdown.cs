
using Pitalytics.Interfaces;
using Pitalytics.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pitalytics.Domain.Utilities 
{
    /// <summary>
    /// 
    /// </summary>
    public static class GetJurisdictionDropdown
    {/// </summary>
        // <summary>
        /// Colors the list items.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="selectedColorId">The selected color identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> GetJurisdicions(IList<IJurisdiction> jurisdictions,
           int selectedBranchId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectJurisdiction,
                    Value = "-1",
                    Selected = false
                }
            };

            if (jurisdictions.Any())
            {
                list.AddRange(jurisdictions.Select(t => new SelectListItem
                {
                    Text = t.JurisdictionName,
                    Value = t.JurisdictionId.ToString(),
                    Selected = selectedBranchId.Equals(t.JurisdictionId)
                }));
            }

            return list;
        }

    }
}


